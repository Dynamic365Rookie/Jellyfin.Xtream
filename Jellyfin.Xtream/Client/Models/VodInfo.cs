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
using Jellyfin.Xtream.Client;
using Newtonsoft.Json;

#pragma warning disable CS1591
namespace Jellyfin.Xtream.Client.Models;

/// <summary>
/// Metadata block returned inside get_vod_info.
/// All numeric fields use FlexibleLongConverter to handle Dispatcharr
/// and other servers that return integers as quoted strings.
/// </summary>
public class VodInfo
{
    [JsonProperty("movie_image")]
    public string? MovieImage { get; set; }

    [JsonProperty("genre")]
    public string? Genre { get; set; }

    [JsonProperty("plot")]
    public string? Plot { get; set; }

    [JsonProperty("director")]
    public string? Director { get; set; }

    /// <summary>
    /// Gets or sets the rating value. Kept as decimal? — same as original.
    /// Most servers send a number; the nullable handles missing values.
    /// </summary>
    [JsonProperty("rating")]
    public decimal? Rating { get; set; }

    [JsonProperty("releasedate")]
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// Gets or sets the duration in seconds.
    /// Dispatcharr may return this as a quoted string → FlexibleLongConverter.
    /// Nullable because the field is sometimes absent.
    /// </summary>
    [JsonProperty("duration_secs")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long? DurationSecs { get; set; }

    /// <summary>
    /// Gets or sets the TMDB identifier.
    /// Dispatcharr may return this as a quoted string → FlexibleLongConverter.
    /// Nullable because the field is sometimes absent.
    /// </summary>
    [JsonProperty("tmdb_id")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long? TmdbId { get; set; }

    /// <summary>
    /// Gets or sets the stream bitrate in kbps.
    /// Dispatcharr may return this as a quoted string → FlexibleLongConverter.
    /// </summary>
    [JsonProperty("bitrate")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long Bitrate { get; set; }

    [JsonProperty("video")]
    [JsonConverter(typeof(OnlyObjectConverter<VideoInfo>))]
    public VideoInfo? Video { get; set; }

    [JsonProperty("audio")]
    [JsonConverter(typeof(OnlyObjectConverter<AudioInfo>))]
    public AudioInfo? Audio { get; set; }
}
