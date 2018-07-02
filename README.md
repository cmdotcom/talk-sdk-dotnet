[![Build](https://img.shields.io/appveyor/ci/m-jepson/voiceapisdk/master.svg "Build Status")](https://ci.appveyor.com/project/m-jepson/voiceapisdk/branch/master)
[![Test](https://img.shields.io/appveyor/tests/m-jepson/voiceapisdk/master.svg "Test Status")](https://ci.appveyor.com/project/m-jepson/voiceapisdk/branch/master/tests)
[![NuGetV](https://img.shields.io/nuget/v/CM.Voice.VoiceApi.Sdk.svg "Nuget Version")](https://www.nuget.org/packages/CM.Voice.VoiceApi.Sdk)
[![NuGetVPre](https://img.shields.io/nuget/vpre/CM.Voice.VoiceApi.Sdk.svg "Nuget Prerelease Version")](https://www.nuget.org/packages/CM.Voice.VoiceApi.Sdk)
[![NuGetDownloads](https://img.shields.io/nuget/dt/CM.Voice.VoiceApi.Sdk.svg "Nuget downloads")](https://www.nuget.org/packages/CM.Voice.VoiceApi.Sdk)

# VoiceApiSdk
SDK for use with the CM VoiceAPI

## API Documentation

https://docs.cmtelecom.com/voice-api-apps/v2.0

# Usage

## Instantiate a client

```cs
var httpClient = new HttpClient();
var voiceApiClient = new VoiceApiClient(httpClient, myApiKey);
```

`httpClient` is requested as a parameter, such that you can use a single instance throughout your application, as is highly recommended.
Ideally you would have it injected by Dependency Injection.

`myApiKey` is your unique api key (or product token) which authorizes you on the CM platform. Always keep this key secret!

## Sending an instruction

Before we can send an instruction, we need to create one.

```cs
var instruction = new NotificationInstruction
{
    InstructionId = "My InstructionId",
    Caller = "+1234567890",
    Callee = "+9876543210",
    PromptType = PromptType.TTS,
    Prompt = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent eu laoreet augue. Fusce fermentum auctor pellentesque.",
    Voice = new Voice
    {
        Language = "nl-NL",
        Gender = Gender.Female,
        Number = 1
    }
};
```

This is an example Notification instruction, which will simply call the `Callee` while showing the `Caller`. 
When picked up, it will read the prompt using the specified voice and hang up.

The other instructions are the `OtpInstruction` (for sending a One Time Password) and the `RequestDtmfInstruction` (for calling and requesting numerical input from the callee).
More information on the various fields and their uses can be found in the docs (https://docs.cmtelecom.com/voice-api-apps/v2.0), as well as the list of possible voices.

To send the instruction, simply call `SendAsync()`  on the client and the call should take place shortly after.

```cs
var result = await voiceApiClient.SendAsync(instruction).ConfigureAwait(false);
```

Finally, the result will have a `HttpStatusCode`, `Content` (as string), a boolean indicating `Success` and a call `DeserializeEvent()` to Deserialize the result into a `CallQueuedEvent`

