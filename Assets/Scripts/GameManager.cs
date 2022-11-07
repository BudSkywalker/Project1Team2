using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool hasMouse;
    public static string ActiveLevel
    {
        get
        {
            return activeLevel;
        }
    }
    private static string activeLevel;
    public static bool captions;
    public TMP_Text guessDipslay;
    public static GameManager Instance;
    [SerializeField]
    private AudioSource audioPlayer;
    [SerializeField]
    private AudioSource wrongGuess;
    [SerializeField]
    private RuntimeAnimatorController contoller;
    [SerializeField]
    private AudioClip deathClip;
    [SerializeField]
    private UnityEngine.UI.Image deathDisplay;
    private static int strikesLeft = 5;
    private string[] levels = {"TUTORIAL", "LEVEL_ONE", "LEVEL_TWO", "LEVEL_THREE", "CREDITS" };
    [SerializeField]
    private TextWriter captionWriter;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this) Destroy(gameObject);
        }

        activeLevel = SceneManager.GetActiveScene().name;
        if(guessDipslay != null) guessDipslay.text = "Remaining Guesses: " + strikesLeft;

        Cursor.lockState = CursorLockMode.None;
        if (hasMouse) Cursor.visible = true;
        else Cursor.visible = false;
    }

    public void GuessObject(bool correctGuess)
    {
        if(correctGuess)
        {
            for(int i = 0; i < levels.Length - 1; i++)
            {
                if(levels[i] == SceneManager.GetActiveScene().name)
                    ChangeScene(levels[i+1]);
            }
        }
        else
        {
            if (ActiveLevel == "TUTORIAL")
            {
            }
            else
            {
                strikesLeft--;

                guessDipslay.text = "Remaining Guesses: " + strikesLeft;
                if (strikesLeft <= 0)
                {
                    StartCoroutine(Die());
                }

            }

            wrongGuess.PlayOneShot(wrongGuess.clip);
        }
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator Die()
    {
        GameObject pc = GameObject.Find("PlayerCapsule");
        Vector3 pos = pc.GetComponentInChildren<Camera>().transform.position;
        Quaternion rot = pc.GetComponentInChildren<Camera>().transform.rotation;
        pc.GetComponent<PlayerController>().SetCutscene(true);
        pc.GetComponent<Animator>().enabled = true;
        pc.GetComponent<Animator>().runtimeAnimatorController = contoller;
        pc.transform.position = pos;
        pc.transform.rotation = rot;
        audioPlayer.PlayOneShot(deathClip);
        pc.GetComponent<Animator>().SetTrigger("Death");
        deathDisplay.gameObject.SetActive(true);
        for(int i = 0; i < 100; i++)
        {
            deathDisplay.color = new Color(0,0,0,i/100f);
            yield return new WaitForSecondsRealtime(0.05f);
            Debug.Log(i);
        }
        yield return new WaitForSecondsRealtime(3f);

        strikesLeft = 5;
        ChangeScene("Menu");
    }

    public void ForceSetCaption(string caption)
    {
        captionWriter.StopAllCoroutines();
        captionWriter.message = caption;
        captionWriter.StartTypingMessage();
    }
    public void SetCaption(string caption)
    {
        captionWriter.StopAllCoroutines();
        captionWriter.message = caption;
        if (captions)
        {
            captionWriter.StartTypingMessage();
        }
    }
}
