using System;
using System.Linq;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof( Animator))]
public class GameController : MonoBehaviour
{
    enum GameState { Idle, Walk, Jump};
    GameState curState = GameState.Idle;
    Animator anim;
    // Start is called before the first frame update
    int jumpHash = Animator.StringToHash("Jump");
    int walkHash = Animator.StringToHash("Walk");
    int idleHash = Animator.StringToHash("Idle");
    private StringComparison comp ;

    public Text Debugtext;
    void Start()
    {
        anim = GetComponent<Animator>();
        var scripts = FindObjectsOfType<MonoBehaviour>().OfType<IMessage>();
        foreach(var s in scripts)
        {
            s.message += OnResultSpeech;
         
        }
        //SpeechToText.instance.onResultCallback += OnResultSpeech;
        //SpeechToText.instance.onPartialResultsCallback += OnResultSpeech;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int statehash = GetCurState();
            SetTrigger(statehash);
        }
    }

    void OnResultSpeech(string _data)
    {
        String s = (String)  _data;
        String w = "walk";
        comp = StringComparison.OrdinalIgnoreCase;
        if (s.Contains(w) )
        {
            SetTrigger(walkHash);
            Debugtext.text = "set to walk";
        }
        else if (s.Contains("Jump") || s.Contains("jump"))
        {
            SetTrigger(jumpHash);
            Debugtext.text = "set to Jump";
        }
        else if (_data.Contains("Idle") || _data.Contains("idle")|| _data.Contains("idl"))
        {
            SetTrigger(idleHash);
            Debugtext.text = "set to Idle";
        }
        else
        {
            Debugtext.text = _data;
        }

    }

    void SetTrigger(int hashvale)
    {
        anim.SetTrigger(hashvale);
    }

    int GetCurState()
    {
        switch (curState)
        {
            case GameState.Idle:
                curState = GameState.Walk;
                return walkHash;
               
            case GameState.Walk:
                curState = GameState.Jump;
                return jumpHash;
            case GameState.Jump:
                curState = GameState.Idle;
              
                return idleHash;
            default:
                return idleHash;

        }


    }
}
