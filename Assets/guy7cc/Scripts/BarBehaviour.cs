using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarBehaviour : MonoBehaviour
{
    [SerializeField]
    private Image bar;

    [Range(0f, 1f)]
    public float value;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        value = Mathf.Max(0, Mathf.Min(1f, value));
        bar.rectTransform.anchoredPosition = new Vector2(4.5f + value * 70.5f, -17.25f);
        bar.rectTransform.sizeDelta = new Vector2(value * 141f, 7.5f);
    }
}
