using CM.Voice.VoiceApi.Sdk;
using CM.Voice.VoiceApi.Sdk.Models;
using CM.Voice.VoiceApi.Sdk.Models.Events;
using CM.Voice.VoiceApi.Sdk.Models.Instructions.Apps;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class ClientTests
    {
        private const string url = "https://api.cmtelecom.com/voiceapi/v2";

        public class FakeHttpMessageHandler : HttpMessageHandler
        {
            public List<(HttpRequestMessage HttpRequestMessage, string Content)> RequestMessages { get; private set; } =
                new List<(HttpRequestMessage HttpRequestMessage, string Content)>();

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestMessages.Add((request, request.Content.ReadAsStringAsync().Result));

                //return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
                return ReturnFunction();
            }

            public delegate Task<HttpResponseMessage> ReturnFunc();
            public ReturnFunc ReturnFunction { get; set; } = () => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        [Fact]
        public void TestNotification()
        {
            var instruction = new NotificationInstruction
            {
                InstructionId = Guid.NewGuid().ToString(),
                Caller = "+1234567890",
                Callee = "+9876543210",
                PromptType = PromptType.TTS,
                Prompt = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu laoreet augue. Fusce fermentum auctor pellentesque.",
                Anonymous = false,
                DisableCalleesValidation = false,
                CallbackUrl = "http://www.random.org",
                Voice = new Voice
                {
                    Language = "nl-NL",
                    Gender = Gender.Female,
                    Number = 1
                }
            };

            var handler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(handler);
            var client = new VoiceApiClient(httpClient, Guid.NewGuid());

            client.SendInstruction(instruction).Wait();

            Assert.Single(handler.RequestMessages);
            var request = handler.RequestMessages.First();
            Assert.Equal(url + "/Notification", request.HttpRequestMessage.RequestUri.AbsoluteUri);
            Assert.Equal(HttpMethod.Post, request.HttpRequestMessage.Method);
            var json = JsonConvert.SerializeObject(instruction);
            Assert.Equal(json, request.Content);
        }

        [Fact]
        public void TestOtp()
        {
            var instruction = new OtpInstruction
            {
                InstructionId = "UnitTest",
                Caller = "+1234567890",
                Callees = new [] { "+9876543210", "+2468013579" },
                IntroPromptType = PromptType.TTS,
                IntroPrompt = "Welcome to the C M password service.",
                CodePromptType = PromptType.File,
                CodePrompt = "prompts/code.wav",
                CodeType = CodeType.Default,
                Code = "abc123",
                CallbackUrl = "http://call.me.back/handler",
                MaxReplays = 2,
                ReplayPromptType = PromptType.TTS,
                ReplayPrompt = "Press 1 to repeat your code",
                OutroPromptType = PromptType.File,
                OutroPrompt = "prompts/bye.wav",
                AutoReplay = false,
                Anonymous = true,
                DisableCalleesValidation = true,
                Voice = new Voice()
            };

            var handler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(handler);
            var client = new VoiceApiClient(httpClient, Guid.NewGuid());

            client.SendInstruction(instruction).Wait();

            Assert.Single(handler.RequestMessages);
            var request = handler.RequestMessages.First();
            Assert.Equal(url + "/OTP", request.HttpRequestMessage.RequestUri.AbsoluteUri);
            Assert.Equal(HttpMethod.Post, request.HttpRequestMessage.Method);
            var json = JsonConvert.SerializeObject(instruction);
            Assert.Equal(json, request.Content);
        }

        [Fact]
        public void TestDtmf()
        {
            var instruction = new RequestDtmfInstruction
            {
                InstructionId = "UnitTest",
                Caller = "+1234567890",
                Callees = new[] { "+9876543210", "+2468013579" },
                PromptType = PromptType.TTS,
                Prompt = "Welcome to the C M password service. Please enter your id number.",
                MinDigits = 4,
                MaxDigits = 8,
                MaxAttempts = 3,
                DigitsRegex = "\\d*",
                TimeOut = 5000,
                Terminators = "#",
                ValidPromptType = PromptType.TTS,
                ValidPrompt = "Thank you for using our service.",
                InvalidPromptType = PromptType.File,
                InvalidPrompt = "idPrompts/wrongInput.wav",
                CallbackUrl = "http://call.me.back/handler",
                Anonymous = true,
                DisableCalleesValidation = true,
                Voice = new Voice
                {
                    Language = "en-IN",
                    Gender = Gender.Female,
                    Number = 2
                }
            };

            var handler = new FakeHttpMessageHandler();
            var httpClient = new HttpClient(handler);
            var client = new VoiceApiClient(httpClient, Guid.NewGuid());

            client.SendInstruction(instruction).Wait();

            Assert.Single(handler.RequestMessages);
            var request = handler.RequestMessages.First();
            Assert.Equal(url + "/DTMF", request.HttpRequestMessage.RequestUri.AbsoluteUri);
            Assert.Equal(HttpMethod.Post, request.HttpRequestMessage.Method);
            var json = JsonConvert.SerializeObject(instruction);
            Assert.Equal(json, request.Content);
        }

        [Fact]
        public void TestCallQueuedEvent()
        {
            var instruction = new NotificationInstruction
            {
                InstructionId = Guid.NewGuid().ToString(),
                Caller = "+1234567890",
                Callee = "+9876543210",
                PromptType = PromptType.TTS,
                Prompt = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu laoreet augue. Fusce fermentum auctor pellentesque.",
                Anonymous = false,
                DisableCalleesValidation = false,
                CallbackUrl = "http://www.random.org",
                Voice = new Voice()
            };

            var evt = new CallQueuedEvent
            {
                Caller = instruction.Caller,
                Callee = instruction.Callee,
                Success = true,
                InstructionId = instruction.InstructionId,
                CallId = Guid.NewGuid(),
                Error = string.Empty
            };

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            var evtJson = JsonConvert.SerializeObject(evt);
            responseMessage.Content = new StringContent(evtJson);
            var handler = new FakeHttpMessageHandler
            {
                ReturnFunction = () => Task.FromResult(responseMessage)
            };
            var httpClient = new HttpClient(handler);
            var client = new VoiceApiClient(httpClient, Guid.NewGuid());

            var result = client.SendInstruction(instruction).Result;

            Assert.Equal(HttpStatusCode.OK, result.HttpStatusCode);
            Assert.Equal(evtJson, result.Content);
            Assert.Equal(evt, result.DeserializeEvent());
        }
    }
}
