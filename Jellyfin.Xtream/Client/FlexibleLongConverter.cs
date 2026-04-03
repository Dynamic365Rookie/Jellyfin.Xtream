// Copyright (C) 2022 Kevin Jilissen
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program. If not, see <https://www.gnu.org/licenses/>.

using System;
using Newtonsoft.Json;

#pragma warning disable CS1591
namespace Jellyfin.Xtream.Client;

/// <summary>
/// A <see cref="JsonConverter"/> that accepts both bare JSON integers and
/// JSON strings containing integer values when deserializing to <see cref="long"/>.
///
/// <para>
/// Several Xtream Codes-compatible servers — including Dispatcharr — serialise
/// numeric identifiers as quoted strings, e.g.:
/// <code>"id": "6194717756870245077"</code>
/// instead of the expected:
/// <code>"id": 6194717756870245077</code>
/// Newtonsoft.Json throws a <see cref="Newtonsoft.Json.JsonReaderException"/>
/// by default when it encounters this pattern on an <c>int</c> or <c>long</c>
/// property. This converter silently handles both representations.
/// </para>
///
/// <para>
/// Overflow handling: values that exceed <see cref="long.MaxValue"/> are cast
/// with <c>unchecked</c> rather than throwing, which preserves a stable (if
/// wrapped) value that can still serve as a unique key.
/// </para>
/// </summary>
public class FlexibleLongConverter : JsonConverter<long>
{
    /// <inheritdoc />
    public override long ReadJson(
        JsonReader reader,
        Type objectType,
        long existingValue,
        bool hasExistingValue,
        JsonSerializer serializer)
    {
        switch (reader.TokenType)
        {
            case JsonToken.String:
            {
                string? raw = reader.Value as string;
                if (string.IsNullOrWhiteSpace(raw))
                {
                    return 0L;
                }

                // Parse via decimal first: handles values > Int64.MaxValue
                // (e.g. 8996515765206861700 fits in ulong but not long)
                // without throwing OverflowException.
                if (decimal.TryParse(
                    raw,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out decimal dec))
                {
                    return unchecked((long)(ulong)dec);
                }

                return 0L;
            }

            case JsonToken.Integer:
                return Convert.ToInt64(
                    reader.Value,
                    System.Globalization.CultureInfo.InvariantCulture);

            case JsonToken.Float:
                // Some servers return 12345.0 — handle gracefully.
                return unchecked((long)Convert.ToDouble(
                    reader.Value,
                    System.Globalization.CultureInfo.InvariantCulture));

            default:
                return 0L;
        }
    }

    /// <inheritdoc />
    public override void WriteJson(
        JsonWriter writer,
        long value,
        JsonSerializer serializer)
        => writer.WriteValue(value);
}
