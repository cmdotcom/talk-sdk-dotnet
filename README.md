| branch | build status | test status |
| --- | --- | --- |
| master | [![build](https://img.shields.io/appveyor/ci/m-jepson/voiceapisdk/master.svg "Build Status")](https://ci.appveyor.com/project/m-jepson/voiceapisdk/branch/master) | [![test](https://img.shields.io/appveyor/tests/m-jepson/voiceapisdk/master.svg "Test Status")](https://ci.appveyor.com/project/m-jepson/voiceapisdk/branch/master/tests)
| develop | [![build](https://img.shields.io/appveyor/ci/m-jepson/voiceapisdk/develop.svg "Build Status")](https://ci.appveyor.com/project/m-jepson/voiceapisdk/branch/develop) | [![test](https://img.shields.io/appveyor/tests/m-jepson/voiceapisdk/develop.svg "Test Status")](https://ci.appveyor.com/project/m-jepson/voiceapisdk/branch/develop/tests)

# VoiceApiSdk
SDK for use with the CM VoiceAPI

## API Documentation

https://docs.cmtelecom.com/voice-api-apps/v2.0

# Usage

## Instantiate a client

```cs
var client = new VoiceApiClient(httpClient, myApiKey);
```

`httpClient` is requested as a parameter, such that you can use a single instance throughout your application, as is highly recommended.
Ideally you would have it injected by Dependency Injection.
`apiKey` is your unique api key (or product token) which authorizes you on the CM platform. Always keep this key secret!

## Sending an instruction

Before we can send an instruction, we need to create one.

```cs
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
```

This is an example Notification instruction, which will simyply call the `Callee` while showing the `Caller`. 
When picked up, it will read the prompt using the specified voice and hang up.

To send the instruction, simply call `SendInstruction`  on the client and the call should take place shortly after.

```cs
var result = client.SendInstruction(instruction).Result;
```

Finally, the result will have a `HttpStatusCode`, `Content` (as string), a boolean indicating `Success` and a call `DeserializeEvent` to Deserialize the result into a `CaallQueuedEvent`

