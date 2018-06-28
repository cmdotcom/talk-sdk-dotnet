using CM.Voice.VoiceApi.Sdk.Models;
using CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps;
using Xunit;

namespace Tests
{
    public class ModelTests
    {
        [Theory]
        [InlineData("en-UK", Gender.Male, 2)]
        [InlineData("de-DE", Gender.Female, 2)]
        [InlineData("fr-FR", Gender.Male, 1)]
        [InlineData("sv-SE", Gender.Female, 1)]
        public void VoicesEqual(string language, Gender gender, int number)
        {
            var instance1 = new Voice()
            {
                Language = language,
                Gender = gender,
                Number = number
            };

            var instance2 = new Voice()
            {
                Language = language,
                Gender = gender,
                Number = number
            };

            Assert.Equal(instance1, instance2);
        }

        [Theory]
        [InlineData("fr-FR", Gender.Male, 1)]
        [InlineData("en-UK", Gender.Female, 1)]
        [InlineData("en-UK", Gender.Male, 2)]
        public void VoicesNotEqual(string language, Gender gender, int number)
        {
            var instance1 = new Voice()
            {
                Language = "en-UK",
                Gender = Gender.Male,
                Number = 1
            };

            var instance2 = new Voice()
            {
                Language = language,
                Gender = gender,
                Number = number
            };

            Assert.NotEqual(instance1, instance2);
        }


        [Theory]
        [InlineData("+1234567890", "+0987654321", "instruction", false, "http://call.back", false, "prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654321", "instruction", true, "http://www.cm.com/callback", true, "Something something.", PromptType.TTS)]
        [InlineData("nonsense", "more nonsense", "1cee47c6-b02d-497c-848a-568985199d89", false, "http://call.back", false, "prompt.wav", PromptType.File)]
        // This also takes care of the BaseAppInstruction fields.
        public void NotificationInstructionsEqual(string caller, string callee, string instructionId, bool anonymous, string callbackUrl, bool disableCalleesValidation, string prompt, PromptType promptType)
        {
            var instance1 = new NotificationInstruction
            {
                Callee = caller,
                Caller = callee,
                InstructionId = instructionId,
                Anonymous = anonymous,
                CallbackUrl = callbackUrl,
                DisableCalleesValidation = disableCalleesValidation,
                Prompt = prompt,
                PromptType = promptType,
                Voice = new Voice()
            };

            var instance2 = new NotificationInstruction
            {
                Callee = caller,
                Caller = callee,
                InstructionId = instructionId,
                Anonymous = anonymous,
                CallbackUrl = callbackUrl,
                DisableCalleesValidation = disableCalleesValidation,
                Prompt = prompt,
                PromptType = promptType,
                Voice = new Voice()
            };

            Assert.Equal(instance1, instance2);
        }

        //TODO Also test the Callees field of the BaseAppInstruction.

        [Theory]
        [InlineData("+1234567899", "+0987654321", "instruction", false, "http://call.back", false, "prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654320", "instruction", false, "http://call.back", false, "prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654321", "other", false, "http://call.back", false, "prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654321", "instruction", true, "http://call.back", false, "prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654321", "instruction", false, "http://www.cm.com/callback", false, "prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654321", "instruction", false, "http://call.back", true, "prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654321", "instruction", false, "http://call.back", false, "dir/prompt.wav", PromptType.File)]
        [InlineData("+1234567890", "+0987654321", "instruction", false, "http://call.back", false, "prompt.wav", PromptType.TTS)]
        // This also takes care of the BaseAppInstruction fields.
        public void NotificationInstructionsNotEqual(string caller, string callee, string instructionId, bool anonymous, string callbackUrl, bool disableCalleesValidation, string prompt, PromptType promptType)
        {
            var instance1 = new NotificationInstruction
            {
                Callee = "+1234567890",
                Caller = "+0987654321",
                InstructionId = "instruction",
                Anonymous = false,
                CallbackUrl = "http://call.back",
                DisableCalleesValidation = false,
                Prompt = "prompt.wav",
                PromptType = PromptType.File,
                Voice = new Voice()
            };

            var instance2 = new NotificationInstruction
            {
                Callee = caller,
                Caller = callee,
                InstructionId = instructionId,
                Anonymous = anonymous,
                CallbackUrl = callbackUrl,
                DisableCalleesValidation = disableCalleesValidation,
                Prompt = prompt,
                PromptType = promptType,
                Voice = new Voice()
            };

            Assert.NotEqual(instance1, instance2);
        }

        [Theory]
        [InlineData("test", PromptType.TTS, "code is", PromptType.TTS, "replay", PromptType.TTS, "outro", PromptType.TTS, "code", CodeType.TTS, 3, false)]
        [InlineData("prompt.wav", PromptType.File, "codeprompt.wav", PromptType.File, "replay.wav", PromptType.File, "outro.wav", PromptType.File, "code", CodeType.Custom, 5, true)]
        [InlineData("test", PromptType.TTS, "code is", PromptType.TTS, "replay", PromptType.TTS, "outro", PromptType.TTS, "code", CodeType.Default, 3, false)]
        public void OtpInstructionsEqual(string introPrompt, PromptType introPromptType, string codePrompt, PromptType codePromptType, string replayPrompt, PromptType replayPromptType,
            string outroPrompt, PromptType outroPromptType, string code, CodeType codeType, int maxReplays, bool autoReplay)
        {
            var instance1 = new OtpInstruction
            {
                IntroPrompt = introPrompt,
                IntroPromptType = introPromptType,
                CodePrompt = codePrompt,
                CodePromptType = codePromptType,
                ReplayPrompt = replayPrompt,
                ReplayPromptType = replayPromptType,
                OutroPrompt = outroPrompt,
                OutroPromptType = outroPromptType,
                Code = code,
                CodeType = codeType,
                MaxReplays = maxReplays,
                AutoReplay = autoReplay,
                Voice = new Voice()
            };

            var instance2 = new OtpInstruction
            {
                IntroPrompt = introPrompt,
                IntroPromptType = introPromptType,
                CodePrompt = codePrompt,
                CodePromptType = codePromptType,
                ReplayPrompt = replayPrompt,
                ReplayPromptType = replayPromptType,
                OutroPrompt = outroPrompt,
                OutroPromptType = outroPromptType,
                Code = code,
                CodeType = codeType,
                MaxReplays = maxReplays,
                AutoReplay = autoReplay,
                Voice = new Voice()
            };

            Assert.Equal(instance1, instance2);
        }


    }
}
