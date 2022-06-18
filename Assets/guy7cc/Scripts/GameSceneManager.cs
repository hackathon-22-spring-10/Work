using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public GameObject gameResultPrefab;

    private GameObject girlObj;
    private Girl girl;

    private bool isEnding = false;

    private const float goalLineX = 74.585f;

    private void Awake()
    {
        girlObj = GameObject.Find("Girl");
        girl = girlObj.GetComponent<Girl>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnding && girlObj.transform.position.x >= goalLineX)
        {
            isEnding = true;
            StartCoroutine(GameEndRoutine());
        }
    }

    private IEnumerator GameEndRoutine()
    {
        //scene transition effects here
        for (float t = 0; t <= 2f; t += Time.deltaTime)
        {
            yield return null;
        }

        OnSceneChange();
        yield break;
    }

    private void OnSceneChange()
    {
        GameObject resultObject = Instantiate(gameResultPrefab);
        resultObject.name = "GameResult";
        GameResult result = resultObject.GetComponent<GameResult>();
        Girl girl = GameObject.Find("Girl").GetComponent<Girl>();
        result.hp = girl.hitPoint;
        result.fav = girl.favorabilityRating;

        DontDestroyOnLoad(resultObject);
        SceneManager.LoadScene("GameEndScene");
    }
}
