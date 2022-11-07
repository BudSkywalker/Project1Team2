using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialGM : MonoBehaviour
{
    public static TutorialGM Instance;

    public TMP_Text objectiveTextbox;
    public Image hintTarget;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private Sprite[] hints;
    private bool[] triggers;
    private int clipNum = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(this);
            }
        }
    }

    private void Start()
    {
        triggers = new bool[clips.Length];
        SetTrigger(0);

        StartCoroutine(PlaySound());
    }

    private void Update()
    {
        if (GetTrigger(0)) objectiveTextbox.text = "Move using WASD";
        if (GetTrigger(1)) objectiveTextbox.text = "Interact with secretary";
        if (GetTrigger(2)) objectiveTextbox.text = "Press Q or I to check notes";
        if (GetTrigger(3)) objectiveTextbox.text = "Press E to pick up the notebook";
        if (GetTrigger(4)) objectiveTextbox.text = "Press E to interact with objects";
        if (GetTrigger(5)) objectiveTextbox.text = "Press G to enter guess mode";
        if (GetTrigger(6)) objectiveTextbox.text = "Guess the correct food";

        hintTarget.sprite = hints[clipNum - 1];
    }

    public void SetTrigger(int num)
    {
        triggers[num] = true;

        int large = 0;
        for(int i = 0; i < triggers.Length; i++)
        {
            if (triggers[i]) large = i;
        }

        if (GameManager.captions)
        {
            switch(large)
            {
                case 0:
                    GameManager.Instance.SetCaption("I've been sitting here a while. I should probably walk around. I can move using WASD.");
                    break;
                case 1:
                    GameManager.Instance.SetCaption("Let me talk to my secretary and see if they need anything. I should walk up to her and press 'e' to interact.");
                    break;
                case 2:
                    GameManager.Instance.SetCaption("If I forget something I can always press 'q' or 'i' to check my notes.");
                    break;
                case 3:
                    GameManager.Instance.SetCaption("It looks like I don't have any notes yet.");
                    break;
                case 4:
                    GameManager.Instance.SetCaption("I can also interact with objects by pressing 'e' to pick them up and place them down.");
                    break;
                case 5:
                    GameManager.Instance.SetCaption("In order to guess I can press 'g' to enter guess mode and press 'e' while in guess mode to lock in my guess.");
                    break;
                case 6:
                    GameManager.Instance.SetCaption("I better make sure I back up in full view of the object to be able to guess.");
                    break;
                default:
                    GameManager.Instance.SetCaption("");
                    break;
            }
            
        }
    }

    public bool GetTrigger(int num)
    {
        return triggers[num];
    }

    public IEnumerator PlaySound()
    {
        while(clipNum < clips.Length)
        {
            if (source.isPlaying)
            {
                yield return new WaitForEndOfFrame();
                continue;
            }
            if (triggers[clipNum])
            {
                source.PlayOneShot(clips[clipNum]);
                clipNum++;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
