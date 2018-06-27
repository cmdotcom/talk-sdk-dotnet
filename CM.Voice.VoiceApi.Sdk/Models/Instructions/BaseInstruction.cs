using Newtonsoft.Json;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions
{
    /// <summary>
    /// The base for all instructions.
    /// </summary>
    public abstract class BaseInstruction
    {
        /// <summary>
        /// The type of the instruction
        /// </summary>
        [JsonProperty("type", Order = 1)]
        public string Type => this.InstructionType;

        /// <summary>
        /// The ID of the instruction.
        /// </summary>
        [JsonProperty("instruction-id", Order = 3)]
        public string InstructionId { get; set; }

        /// <summary>
        /// Again the type, which needs to be overridden so the "Type" property returns the correct type.
        /// </summary>
        protected abstract string InstructionType { get; }
    }
}
