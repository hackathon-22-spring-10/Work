using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject gameResultPrefab;

    private GameObject girlObj;
    private Girl girl;
    private PlayerManager playerManager;
    private GameObject dead;
    private GameObject clear;
    private CameraManager cam;
    private GameSceneAudioManager audio;

    public AudioClip clearSound;

    private bool isEnding = false;

    private const float goalLineX = 74.585f;

    private void Awake()
    {
        girlObj = GameObject.Find("Girl");
        girl = girlObj.GetComponent<Girl>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        dead = GameObject.Find("Dead");
        clear = GameObject.Find("Clear");
        cam = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        audio = GameObject.Find("AudioSource").GetComponent<GameSceneAudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dead.SetActive(false);
        clear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnding && girlObj.transform.position.x >= goalLineX)
        {
            isEnding = true;
            StartCoroutine(GameEndRoutine());
        }
        if(!isEnding && girl.hitPoint <= 0)
        {
            isEnding = true;
            StartCoroutine(DeadRoutine());
        }
    }

    private IEnumerator DeadRoutine()
    {
        playerManager.Inactivate();
        audio.SetDead();
        dead.SetActive(true);
        cam.SetDeadEffect();
        Time.timeScale = 0.00001f;
        for (float t = 0; t <= 0.00005f; t += Time.deltaTime)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        OnGameEnd();
        yield break;
    }

    private IEnumerator GameEndRoutine()
    {
        audio.SetClear();
        clear.SetActive(true);
        Time.timeScale = 0.00001f;
        for (float t = 0; t <= 0.000035f; t += Time.deltaTime)
        {
            yield return null;
        }
        Time.timeScale = 1f;
        OnGameEnd();
        yield break;
    }

    private void OnGameEnd()
    {
        GameObject resultObject = Instantiate(gameResultPrefab);
        resultObject.name = "GameResult";
        GameResult result = resultObject.GetComponent<GameResult>();
        Girl girl = GameObject.Find("Girl").GetComponent<Girl>();
        result.hp = girl.hitPoint;
        result.fav = girl.favorability;

        DontDestroyOnLoad(resultObject);
        SceneManager.LoadScene("GameEndScene");
    }
}
