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
/// Represents a live stream, VOD stream, or channel metadata entry as returned
/// by get_live_streams / get_vod_streams.
///
/// All numeric fields use FlexibleLongConverter to handle Dispatcharr (and
/// other servers) that return integers as quoted JSON strings.
/// </summary>
public class StreamInfo
{
    /// <summary>
    /// Position index in the server's list.
    /// </summary>
    [JsonProperty("num")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long Num { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("stream_type")]
    public string StreamType { get; set; } = string.Empty;

    /// <summary>
    /// Unique stream identifier.
    /// Dispatcharr may return this as a quoted string.
    /// </summary>
    [JsonProperty("stream_id")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long StreamId { get; set; }

    [JsonProperty("stream_icon")]
    public string StreamIcon { get; set; } = string.Empty;

    [JsonProperty("epg_channel_id")]
    public string EpgChannelId { get; set; } = string.Empty;

    /// <summary>
    /// Unix timestamp (as string) of when the stream was added.
    /// Kept as string because some providers send epoch strings, others send
    /// date strings — we only need it for informational purposes.
    /// </summary>
    [JsonProperty("added")]
    public string Added { get; set; } = string.Empty;

    /// <summary>
    /// Primary category identifier.
    /// Nullable because some servers omit this field.
    /// </summary>
    [JsonProperty("category_id")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long? CategoryId { get; set; }

    [JsonProperty("container_extension")]
    public string ContainerExtension { get; set; } = string.Empty;

    [JsonProperty("custom_sid")]
    public string CustomSid { get; set; } = string.Empty;

    [JsonProperty("tv_archive")]
    public bool TvArchive { get; set; }

    [JsonProperty("direct_source")]
    public string DirectSource { get; set; } = string.Empty;

    /// <summary>
    /// Catchup/archive duration in hours.
    /// </summary>
    [JsonProperty("tv_archive_duration")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long TvArchiveDuration { get; set; }
}
