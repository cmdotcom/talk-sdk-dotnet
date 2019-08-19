namespace CM.Voice.VoiceApi.Sdk.Models
{
    /// <summary>
    /// Determines the response when a voicemail beep is detected.
    /// </summary>
    public enum VoicemailResponse
    {
        /// <summary>
        /// Ignores Voicemail detection.
        /// </summary>
        Ignore,

        /// <summary>
        /// Restarts when Voicemail has been detected.
        /// </summary>
        Restart,

        /// <summary>
        /// Stops the call when Voicemail has been detected.
        /// </summary>
        Stop
    }
}