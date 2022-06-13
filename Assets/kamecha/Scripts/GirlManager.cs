using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlManager : MonoBehaviour
{
    [SerializeField]
    private GameObject girlPrefab;
    private GameObject girl;
    void Start()
    {
        girl = Instantiate(girlPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        // Debug.Log(girl.hitPoint);
        Debug.Log(girl.GetComponent<Girl>().hitPoint);
    }
}
