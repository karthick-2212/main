import { SpeechConfig, AudioConfig, SpeechSynthesizer, ResultReason } from 'microsoft-cognitiveservices-speech-sdk';
export class GlobalFunctions {
    public static IsNullorEmpty(input: string) {
        return input === undefined || input === null || input.match(/^ *$/) !== null;
    }

    public static StandardPronunciation(fullname: string, selectedcountry: string) {
        console.log(fullname);
        var key = "7ef35f6306fa4d8c9f4effc70c5db688";
        var region = "eastus";

        const speechConfig = SpeechConfig.fromSubscription(key, region);
        const audioConfig = AudioConfig.fromDefaultSpeakerOutput();

        // The language of the voice that speaks.
        speechConfig.speechSynthesisVoiceName = selectedcountry;

        // Create the speech synthesizer.
        var synthesizer = new SpeechSynthesizer(speechConfig, audioConfig);


        // Start the synthesizer and wait for a result.
        synthesizer.speakTextAsync(fullname,
            function (result: any) {
                if (result.reason === ResultReason.SynthesizingAudioCompleted) {
                    console.log("synthesis finished.");
                } else {
                    console.error("Speech synthesis canceled, " + result.errorDetails +
                        "\nDid you set the speech resource key and region values?");
                }
                synthesizer.close();
                //synthesizer = null;
            },
            function (err: any) {
                console.trace("err - " + err);
                synthesizer.close();
                //synthesizer = null;
            });
    }
}
