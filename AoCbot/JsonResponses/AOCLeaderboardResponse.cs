using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace AoCbot.JsonResponses
{
  public partial class AOCLeaderboardResponse
  {
    private List<AOCCompletedDay>();

    [JsonProperty("members", NullValueHandling = NullValueHandling.Ignore)]
    private Members TheMembers { get; set; }

    [JsonProperty("event", NullValueHandling = NullValueHandling.Ignore)]
    public string Event { get; private set; } = "";

    [JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
    public long? OwnerId { get; private set; }

    public string Name => this.TheMembers.The38753.Name;

    public long? GlobalScore => this.TheMembers.The38753.GlobalScore;

    public Dictionary<string, Dictionary<string, CompletionDayLevel>> CompletedDays => this.TheMembers.The38753.CompletionDayLevel;

    private static readonly JsonSerializerSettings JSSettings = new JsonSerializerSettings
    {
      MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
      DateParseHandling = DateParseHandling.None,
      Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal } },
    };

    public static AOCLeaderboardResponse? FromJson(string json) => JsonConvert.DeserializeObject<AOCLeaderboardResponse>(json, AOCLeaderboardResponse.JSSettings);

    private partial class Members
    {
      [JsonProperty("38753", NullValueHandling = NullValueHandling.Ignore)]
      public The38753 The38753 { get; set; }
    }

    private partial class The38753
    {
      [JsonProperty("global_score", NullValueHandling = NullValueHandling.Ignore)]
      public long? GlobalScore { get; set; }

      [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
      public string Name { get; set; }

      [JsonProperty("completion_day_level", NullValueHandling = NullValueHandling.Ignore)]
      public Dictionary<string, Dictionary<string, CompletionDayLevel>> CompletionDayLevel { get; private set; }

      [JsonProperty("local_score", NullValueHandling = NullValueHandling.Ignore)]
      public long? LocalScore { get; set; }

      [JsonProperty("stars", NullValueHandling = NullValueHandling.Ignore)]
      public long? Stars { get; set; }

      [JsonProperty("last_star_ts", NullValueHandling = NullValueHandling.Ignore)]
      public long? LastStarTs { get; set; }

      [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
      public long? Id { get; set; }
    }

    private partial class CompletionDayLevel
    {
      [JsonProperty("star_index", NullValueHandling = NullValueHandling.Ignore)]
      public long? StarIndex { get; set; }

      [JsonProperty("get_star_ts", NullValueHandling = NullValueHandling.Ignore)]
      public long? GetStarTs { get; set; }
    }

  }


  

}
