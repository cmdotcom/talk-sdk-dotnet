using System.Collections.Generic;
using Newtonsoft.Json;

namespace CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps
{
    /// <summary>
    /// This sends the instruction to make and outbound call and start a FlowBuilder flow.
    /// </summary>
    public class FlowBuilderInstruction : BaseAppInstruction
    {
        /// <summary>
        /// The unique identifier of the FlowBuilder flow.
        /// </summary>
        [JsonProperty("callflow-id", Order = 7)]
        public string CallflowId { get; set; }
        
        /// <summary>
        /// Optional list of flow variables that will be set.
        /// </summary>
        [JsonProperty("flow-variables", Order = 8)]
        public Dictionary<string, object> FlowVariables { get; set; }
        
        /// <summary>
        /// Determines the Voicemail detection flow.
        /// </summary>
        [JsonProperty("voicemail-response", Order = 9)]
        public VoicemailResponse VoicemailResponse { get; set; } = VoicemailResponse.Stop;
    }
}