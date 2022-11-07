using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Sprite[] images;

    [SerializeField]
    private Image background;

    void Start()
    {
        StartCoroutine(BackgroundTimer());
    }

    private IEnumerator BackgroundTimer()
    {
        while(true)
        {
            background.sprite = images[Random.Range(0, images.Length)];
            yield return new WaitForSecondsRealtime(120f);
        }
    }
}
