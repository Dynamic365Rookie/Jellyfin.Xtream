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
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

#pragma warning disable CS1591
namespace Jellyfin.Xtream.Client.Models;

/// <summary>
/// Represents a series entry as returned by get_series.
///
/// Dispatcharr (and several other Xtream-compatible servers) may return
/// numeric fields (series_id, category_id, …) as quoted JSON strings.
/// All such fields use FlexibleLongConverter.
///
/// Fields that are sometimes a string and sometimes a number on different
/// providers (rating, episode_run_time) are typed as string? to avoid
/// JsonReaderException and are nullable so missing values are graceful.
/// </summary>
public class Series
{
    [JsonProperty("num")]
    public int Num { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique series identifier.
    /// Dispatcharr may return this as a quoted string.
    /// </summary>
    [JsonProperty("series_id")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long SeriesId { get; set; }

    [JsonProperty("cover")]
    public string Cover { get; set; } = string.Empty;

    [JsonProperty("plot")]
    public string Plot { get; set; } = string.Empty;

    [JsonProperty("cast")]
    public string Cast { get; set; } = string.Empty;

    [JsonProperty("director")]
    public string Director { get; set; } = string.Empty;

    [JsonProperty("genre")]
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last-modified Unix timestamp.
    /// Some providers send a float string, others an integer — kept as string.
    /// </summary>
    [JsonConverter(typeof(UnixDateTimeConverter))]
    [JsonProperty("last_modified")]
    public DateTime LastModified { get; set; }

    /// <summary>
    /// Gets or sets the rating value. Some providers return "8.5", others return 8.5 (bare number).
    /// Typed as decimal to handle both via JSON coercion.
    /// </summary>
    [JsonProperty("rating")]
    public decimal Rating { get; set; }

    [JsonProperty("rating_5based")]
    public decimal Rating5Based { get; set; }

    [JsonConverter(typeof(SingularToListConverter<string>))]
    [JsonProperty("backdrop_path")]
#pragma warning disable CA2227
    public ICollection<string> BackdropPaths { get; set; } = new List<string>();
#pragma warning restore CA2227

    [JsonProperty("youtube_trailer")]
    public string YoutubeTrailer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the episode run time in minutes.
    /// Some providers return this as a string (""), some as an integer (0).
    /// FlexibleLongConverter handles both gracefully.
    /// </summary>
    [JsonProperty("episode_run_time")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long EpisodeRunTime { get; set; }

    /// <summary>
    /// Gets or sets the category identifier.
    /// Dispatcharr may return this as a quoted string.
    /// </summary>
    [JsonProperty("category_id")]
    [JsonConverter(typeof(FlexibleLongConverter))]
    public long CategoryId { get; set; }
}
