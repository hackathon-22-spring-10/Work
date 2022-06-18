using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyKeyBehaviour : MonoBehaviour
{
    private float time = 0;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Min(1f, 1f - 1f * Mathf.Cos(time * Mathf.PI / 2f)));
    }
}
