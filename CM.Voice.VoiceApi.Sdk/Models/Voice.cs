using System.Text.Json.Serialization;

namespace CM.Voice.VoiceApi.Sdk.Models
{
    /// <summary>
    /// The properties in this class are used to select the required TTS voice.
    /// </summary>
    public class Voice
    {
        /// <summary>
        /// The language (5 character locale) of the voice to use. Examples: en-US, en-GB, nl-NL. Defaults to en-GB
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; } = "en-GB";

        /// <summary>
        /// The gender of the voice, either female or male. Defaults to Female.
        /// </summary>
        [JsonPropertyName("gender")]
        public Gender Gender { get; set; } = Gender.Female;

        /// <summary>
        /// Usually one, but if the selected language and gender support multiple voices, you can use this to make a selection between the different ones. Defaults to 1.
        /// </summary>
        [JsonPropertyName("number")]
        public int Number { get; set; } = 1;

        /// <summary>
        /// Volume of the speaking voice. Defaults to 0.
        /// </summary>
        /// <remarks>Allowed values are -4, -3, -2, -1, 0, 1, 2, 3 or 4.</remarks>
        [JsonPropertyName("volume")]
        public sbyte Volume { get; set; }
    }
}