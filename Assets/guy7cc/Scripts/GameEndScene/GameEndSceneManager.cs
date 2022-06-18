using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndSceneManager : MonoBehaviour
{
    public Sprite gameOver;
    public Sprite confessionFailure;
    public Sprite confessionSuccess;

    private GameObject result;
    private GameObject black;
    private GameObject backGround;
    private GameObject gameOverBubble;
    private GameObject gameClearBubble;

    private float time = 0;
    private bool keyPressed = false;

    private void Awake()
    {
        result = GameObject.Find("GameResult");
        black = GameObject.Find("Black");
        backGround = GameObject.Find("BackGround");
        gameOverBubble = GameObject.Find("GameOver");
        gameClearBubble = GameObject.Find("GameClear");
    }

    // Start is called before the first frame update
    void Start()
    {
        Image image = backGround.GetComponent<Image>();
        switch (result != null ? result.GetComponent<GameResult>().GetResult() : GameResult.Result.GameOver)
        {
            case GameResult.Result.GameOver:
                image.sprite = gameOver;
                gameOverBubble.SetActive(true);
                gameClearBubble.SetActive(false);
                break;
            case GameResult.Result.ConfessionFailure:
                image.sprite = confessionFailure;
                gameOverBubble.SetActive(true);
                gameClearBubble.SetActive(false);
                break;
            case GameResult.Result.ConfessionSuccess:
                image.sprite = confessionSuccess;
                gameOverBubble.SetActive(false);
                gameClearBubble.SetActive(true);
                break;
        }
        StartCoroutine(BlackInRoutine(() => { }));
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(!keyPressed && time >= 5f && Input.anyKeyDown)
        {
            keyPressed = true;
            StartCoroutine(BlackOutRoutine(() =>
            {
                //next Scene
                SceneManager.LoadScene("GameStartScene");
            }));
        }
    }

    public IEnumerator BlackInRoutine(Action lastAction)
    {
        SpriteRenderer sprite = black.GetComponent<SpriteRenderer>();
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
        SpriteRenderer sprite = black.GetComponent<SpriteRenderer>();
        black.SetActive(true);
        for (float t = 0; t <= 2f; t += Time.deltaTime)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, t / 2f);
            yield return null;
        }
        lastAction();
        yield break;
    }
}
