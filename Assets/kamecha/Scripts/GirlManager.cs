using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlManager : MonoBehaviour
{
    [SerializeField]
    private GameObject girl;
    [SerializeField]
    private GameObject hpBar;
    [SerializeField]
    private GameObject favorabilityBar;
    void Start()
    {
    }
    void Update()
    {
        hpBar.GetComponent<BarBehaviour>().value = girl.GetComponent<Girl>().hitPoint / Girl.maxHitPoint;
        favorabilityBar.GetComponent<BarBehaviour>().value = girl.GetComponent<Girl>().favorability / Girl.maxFavorability;
    }
}
