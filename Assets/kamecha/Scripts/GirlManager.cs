using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlManager : MonoBehaviour
{
    [SerializeField]
    private GameObject girlPrefab;
    private GameObject girl;
    private GameObject canvas;
    [SerializeField]
    //↓これプレハブにする必要なさそう
    private GameObject hpSlider;
    void Start()
    {
        //Girl
        girl = Instantiate(girlPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        //UI
        canvas = new GameObject();
        canvas.name = "canvas";
        canvas.AddComponent<Canvas>();
        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();
        hpSlider = Instantiate(hpSlider);
        hpSlider.AddComponent<Canvas>();
        hpSlider.transform.SetParent(canvas.transform);
        hpSlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(-318f, -201f);
    }
    void Update()
    {
        hpSlider.GetComponent<Slider>().value = girl.GetComponent<Girl>().hitPoint / Girl.maxHitPoint;
    }
}
