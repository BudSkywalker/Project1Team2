using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class TextWriter : MonoBehaviour
{
    public float timePerLetter = 0.1f;
    [Multiline]
    public string message;
    public TMP_Text textbox;
    public WriteMode writeMode;

    public void StartTypingMessage()
    {
        StartCoroutine(AnimateMessage());
    }

    IEnumerator AnimateMessage()
    {
        textbox.text = message;
        yield return new WaitForSecondsRealtime(timePerLetter);

        /*foreach (char c in message.ToCharArray())
        {
            textbox.text += c;
            if (textbox.preferredHeight > textbox.GetComponent<RectTransform>().rect.height)
            {
                switch (writeMode)
                {
                    case WriteMode.Overflow:
                        break;
                    case WriteMode.Scroll:
                        textbox.text = textbox.text[1..];
                        if (textbox.preferredHeight > textbox.GetComponent<RectTransform>().rect.height) textbox.text = textbox.text[1..];
                        if (textbox.preferredHeight > textbox.GetComponent<RectTransform>().rect.height) textbox.text = textbox.text[1..];
                        if (textbox.preferredHeight > textbox.GetComponent<RectTransform>().rect.height) textbox.text = textbox.text[1..];
                        if (textbox.preferredHeight > textbox.GetComponent<RectTransform>().rect.height) textbox.text = textbox.text[1..];
                        break;
                    case WriteMode.Delete:
                        textbox.text = "";
                        break;
                    case WriteMode.Stop:
                        yield break;
                    default:
                        Debug.LogError("Unkown Write Mode: " + writeMode);
                        break;

                }
            }
            yield return new WaitForSecondsRealtime(timePerLetter);
        }*/
    }

    public enum WriteMode
    {
        Overflow,
        Scroll,
        Delete,
        Stop
    }
}
