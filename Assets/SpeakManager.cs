using SpeechLib;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpeakManager 
{
    private static SpeakManager _instance;
    public static SpeakManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SpeakManager();
            return _instance;
        }
    }
    private Thread speakThread;
    private SpVoice spVoice;
    public SpeakManager()
    {
        speakThread = new Thread(new ParameterizedThreadStart(SpeakThreadStart));
    }
    public   void Speak(string talk)
    {
        spVoice = new SpVoice();
        speakThread.Start(talk);
    }

     private void SpeakThreadStart(object talk)
    {
        spVoice.Speak(talk.ToString());
    }
}
