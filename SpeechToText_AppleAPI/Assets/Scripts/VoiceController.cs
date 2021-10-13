using UnityEngine;
using UnityEngine.UI;
using TextSpeech;
using UnityEngine.Events;

public class VoiceController : MonoBehaviour
{
   
    public Text inputText;

    public float speakDuration = 3f;
    public enum state { talk, stop, idle };
    public state curState = state.idle;
    public float timer = 0f;

  
    void Start()
    {
        Setting("en-US");
        SpeechToText.instance.onResultCallback = OnResultSpeech;
        //SpeechToText.instance.onPartialResultsCallback += OnResultSpeech;
        curState = state.idle;
    }

   

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > speakDuration)
        {
            switch (curState)
            {
                case state.talk:
                    StartRecording();
                    curState = state.stop;
                    speakDuration = 3f;
                    break;
                case state.stop:
                    StopRecording();
                    curState = state.idle;
                    speakDuration = 1f;
                    break;
                case state.idle:
                    curState = state.talk;
                    speakDuration = 0.2f;

                    break;
                default:
                    break;

            }

            timer = 0;
        }
    }

        public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("Not support in editor.");
#else
        SpeechToText.instance.StopRecording();
#endif

    }
    void OnResultSpeech(string _data)
    {
        inputText.text = _data;
      
    }
    public void OnClickSpeak()
    {
        TextToSpeech.instance.StartSpeak(inputText.text);
    }
    public void  OnClickStopSpeak()
    {
        TextToSpeech.instance.StopSpeak();
    }
    public void Setting(string code)
    {
        TextToSpeech.instance.Setting(code, 1f, 1f);
        SpeechToText.instance.Setting(code);
       
    }
  
}
