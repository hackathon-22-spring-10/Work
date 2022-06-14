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
    private GameObject hpSlider;
    void Start()
    {
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
        hpSlider.GetComponent<Slider>().value = 0.8f;
        //Girl
        girl = Instantiate(girlPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
        Debug.Log(girl.GetComponent<Girl>().hitPoint);
        Debug.Log(hpSlider.GetComponent<Slider>().value);
    }
    void Update()
    {
    }
}
