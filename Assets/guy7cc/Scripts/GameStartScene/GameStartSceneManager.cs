using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartSceneManager : MonoBehaviour
{
    private GameObject titlePlayer;
    private GameObject pressAnyKeyImage;
    private GameObject startButton;
    private GameObject exitButton;
    private GameObject bubbleGirl;
    private GameObject bubblePlayer;
    private GameObject bubbleSmall1;
    private GameObject bubbleSmall2;
    private GameObject black;

    [SerializeField]
    private bool cleared;
    private bool pressedAnyKey;

    private void Awake()
    {
        titlePlayer = GameObject.Find("TitlePlayer");
        pressAnyKeyImage = GameObject.Find("PressAnyKey");
        startButton = GameObject.Find("StartButton");
        exitButton = GameObject.Find("ExitButton");
        bubbleGirl = GameObject.Find("BubbleGirl");
        bubblePlayer = GameObject.Find("BubblePlayer");
        bubbleSmall1 = GameObject.Find("BubbleSmall1");
        bubbleSmall2 = GameObject.Find("BubbleSmall2");
        black = GameObject.Find("Black");
    }

    void Start()
    {
        //get the last scene object here, and get info
        //when game cleared and came back to this scene, cleared = true



        //init
        bubbleGirl.SetActive(!cleared);
        bubblePlayer.SetActive(cleared);
        titlePlayer.GetComponent<TitlePlayerBehaviour>().cleared = cleared;
        pressAnyKeyImage.SetActive(!pressedAnyKey);
        startButton.SetActive(pressedAnyKey);
        exitButton.SetActive(pressedAnyKey);
        black.SetActive(false);
    }

    void Update()
    {
        if (!pressedAnyKey && Input.anyKey)
        {
            pressedAnyKey = true;
            pressAnyKeyImage.SetActive(!pressedAnyKey);
            startButton.SetActive(pressedAnyKey);
            exitButton.SetActive(pressedAnyKey);
        }
    }

    public void OnStartButtonClick()
    {
        titlePlayer.GetComponent<TitlePlayerBehaviour>().StartMoving();
        StartCoroutine(BlackOutRoutine(() =>
        {
            //next scene
        }));
    }


    public void OnExitButtonClick()
    {
        StartCoroutine(BubbleExitRoutine());
        StartCoroutine(BlackOutRoutine(() => 
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }));

    }

    public IEnumerator BubbleExitRoutine()
    {
        bubbleSmall2.GetComponent<BubbleBehaviour>().StartEnding();
        yield return new WaitForSeconds(0.25f);
        bubbleSmall1.GetComponent<BubbleBehaviour>().StartEnding();
        yield return new WaitForSeconds(0.25f);
        bubbleGirl.GetComponent<BubbleBehaviour>().StartEnding();
        bubblePlayer.GetComponent<BubbleBehaviour>().StartEnding();
        yield break;
    }

    public IEnumerator BlackOutRoutine(Action lastAction)
    {
        Image sprite = black.GetComponent<Image>();
        black.SetActive(true);
        for(float t = 0; t <= 2f; t += Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, t / 2f);
            yield return null;
        }
        lastAction();
        yield break;
    }
}
