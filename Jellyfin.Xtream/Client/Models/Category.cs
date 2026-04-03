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

using Newtonsoft.Json;

#pragma warning disable CS1591
namespace Jellyfin.Xtream.Client.Models;

/// <summary>
/// Represents a channel/VOD/series category as returned by
/// get_live_categories, get_vod_categories, or get_series_categories.
///
/// Dispatcharr (and several other Xtream-compatible servers) may return
/// category_id and parent_id as quoted strings → FlexibleLongConverter.
/// </summary>
public class Category
{
    /// <summary>
    /// Gets or sets the unique category identifier.
    /// Dispatcharr may return this as a quoted string.
    /// </summary>
    [JsonProperty("category_id")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long CategoryId { get; set; }

    [JsonProperty("category_name")]
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the parent category identifier (0 = top-level).
    /// Dispatcharr may return this as a quoted string.
    /// </summary>
    [JsonProperty("parent_id")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long ParentId { get; set; }
}
