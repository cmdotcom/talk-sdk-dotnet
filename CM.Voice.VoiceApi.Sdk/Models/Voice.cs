using Newtonsoft.Json;
using System;

namespace CM.Voice.VoiceApi.Sdk.Models
{
    /// <summary>
    /// The properties in this class are used to select the required TTS voice.
    /// </summary>
    public class Voice : IEquatable<Voice>
    {
        public bool Equals(Voice other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Language, other.Language) && Gender == other.Gender && Number == other.Number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Voice) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Language != null ? Language.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Gender;
                hashCode = (hashCode * 397) ^ Number;
                return hashCode;
            }
        }

        /// <summary>
        /// The language (5 character locale) of the voice to use. Examples: en-US, en-GB, nl-NL. Defaults to en-GB
        /// </summary>
        [JsonProperty("language", Order = 1)]
        public string Language { get; set; } = "en-GB";

        /// <summary>
        /// The gender of the voice, either female or male. Defaults to Female.
        /// </summary>
        [JsonProperty("gender", Order = 2)]
        public Gender Gender { get; set; } = Gender.Female;

        /// <summary>
        /// Usually one, but if the selected language and gender support multiple voices, you can use this to make a selection between the different ones. Defaults to 1.
        /// </summary>
        [JsonProperty("number", Order = 3)]
        public int Number { get; set; } = 1;
    }

    /// <summary>
    /// Gender, so either male or female.
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Male
        /// </summary>
        Male,
        /// <summary>
        /// Female
        /// </summary>
        Female
    }
}
