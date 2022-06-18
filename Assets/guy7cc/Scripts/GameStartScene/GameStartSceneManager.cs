using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartSceneManager : MonoBehaviour
{
    private GameObject titlePlayer;
    private GameObject playerShadow;
    private GameObject girlShadow;
    private GameObject pressAnyKeyImage;
    private GameObject logo;
    private GameObject startButton;
    private GameObject exitButton;
    private GameObject bubbleGirl;
    private GameObject bubblePlayer;
    private GameObject bubbleSmall1;
    private GameObject bubbleSmall2;
    private GameObject black;
    private GameObject resultObj;

    public AudioClip click;
    private AudioSource audio;

    [SerializeField]
    private bool cleared;
    private bool pressedAnyKey;

    private void Awake()
    {
        titlePlayer = GameObject.Find("TitlePlayer");
        playerShadow = GameObject.Find("PlayerShadow");
        girlShadow = GameObject.Find("GirlShadow");
        pressAnyKeyImage = GameObject.Find("PressAnyKey");
        logo = GameObject.Find("Logo");
        startButton = GameObject.Find("StartButton");
        exitButton = GameObject.Find("ExitButton");
        bubbleGirl = GameObject.Find("BubbleGirl");
        bubblePlayer = GameObject.Find("BubblePlayer");
        bubbleSmall1 = GameObject.Find("BubbleSmall1");
        bubbleSmall2 = GameObject.Find("BubbleSmall2");
        black = GameObject.Find("Black");
        audio = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        resultObj = GameObject.Find("GameResult");
    }

    void Start()
    {
        //get the last scene object here, and get info
        //when game cleared and came back to this scene, cleared = true
        if(resultObj != null)
        {
            GameResult result = resultObj.GetComponent<GameResult>();
            cleared = result.GetResult() == GameResult.Result.ConfessionSuccess;
        }

        //init
        bubbleGirl.SetActive(!cleared);
        bubblePlayer.SetActive(cleared);
        playerShadow.SetActive(!cleared);
        girlShadow.SetActive(cleared);
        titlePlayer.GetComponent<TitlePlayerBehaviour>().cleared = cleared;
        pressAnyKeyImage.SetActive(!pressedAnyKey);
        startButton.SetActive(pressedAnyKey);
        exitButton.SetActive(pressedAnyKey);
        black.SetActive(true);

        StartCoroutine(BlackInRoutine(() => black.SetActive(false)));

    }

    void Update()
    {
        if (!pressedAnyKey && Input.anyKeyDown)
        {
            pressedAnyKey = true;
            pressAnyKeyImage.SetActive(!pressedAnyKey);
            logo.SetActive(!pressedAnyKey);
            startButton.SetActive(pressedAnyKey);
            exitButton.SetActive(pressedAnyKey);
            audio.PlayOneShot(click);
        }
    }

    public void OnStartButtonClick()
    {
        audio.PlayOneShot(click);
        titlePlayer.GetComponent<TitlePlayerBehaviour>().StartMoving();
        StartCoroutine(BlackOutRoutine(() =>
        {
            if(resultObj != null)
            {
                Destroy(resultObj);
            }
            //next scene
            SceneManager.LoadScene("GameScene");
        }));
    }


    public void OnExitButtonClick()
    {
        audio.PlayOneShot(click);
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

    public IEnumerator BlackInRoutine(Action lastAction)
    {
        Image sprite = black.GetComponent<Image>();
        black.SetActive(true);
        for (float t = 0; t <= 2f; t += Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f - t / 2f);
            yield return null;
        }
        lastAction();
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
