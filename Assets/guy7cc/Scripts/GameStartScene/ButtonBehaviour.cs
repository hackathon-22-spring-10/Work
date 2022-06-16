using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField]
    private RectTransform image;

    [SerializeField]
    private bool mouseOn;

    public bool MouseOn
    {
        get
        {
            return mouseOn;
        }
    }

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        mouseOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseOn)
        {
            time += Time.deltaTime;
            image.anchoredPosition = new Vector2(-10 * Mathf.Sin(time / 0.75f * Mathf.PI) - 5f, 0);
        }
        else
        {
            time = 0;
            image.anchoredPosition = Vector2.zero;
        }
    }

    public void OnPointerEnter()
    {
        mouseOn = true;
    }

    public void OnPointerExit()
    {
        mouseOn = false;
    }
}
