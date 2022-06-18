using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlManager : MonoBehaviour
{
    [SerializeField]
    private GameObject girl;
    [SerializeField]
    private GameObject hpSlider;
    [SerializeField]
    private GameObject favorabilityRatingSlider;
    void Start()
    {
    }
    void Update()
    {
        hpSlider.GetComponent<Slider>().value = girl.GetComponent<Girl>().hitPoint / Girl.maxHitPoint;
        favorabilityRatingSlider.GetComponent<Slider>().value = girl.GetComponent<Girl>().favorabilityRating / Girl.maxFavorabilityRating;
        // Debug.Log(favorabilityRatingSlider.GetComponent<Slider>().value);
    }
}
