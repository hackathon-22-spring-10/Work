using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private GameObject budguy;
    [SerializeField] private GameObject normalObstacle;


    void Start()
    {
        StartCoroutine(GenerateObstacles());
    }

    public IEnumerator GenerateObstacles()
    {
        float startTime = Time.time;
        float spawnCooltime;
        while (true)
        {
            switch ((int)Random.Range(0, 2))
            {
                case 0:
                    Instantiate(ghost, GetSpawnPoint(0, 360), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(budguy, GetSpawnPoint(180, 360), Quaternion.identity);
                    break;

            }

            //ゲーム開始から2分経つとクールタイムが最小になる
            spawnCooltime = Mathf.Max(2, 4 - ((Time.time - startTime) / 60));

            Debug.Log(spawnCooltime);
            yield return new WaitForSeconds(spawnCooltime);
        }
    }

    private Vector2 GetSpawnPoint(float minAngle, float maxAngle)
    {
        float radius = (Camera.main.ViewportToWorldPoint(Vector2.zero) - Camera.main.ViewportToWorldPoint(new Vector2(0.55f, 0.55f))).magnitude;
        float angle = Mathf.Deg2Rad * Random.Range(minAngle, maxAngle);
        Vector2 point = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius + (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        return point;
    }
}
