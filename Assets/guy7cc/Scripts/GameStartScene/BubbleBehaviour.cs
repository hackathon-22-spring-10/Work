using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    public float offset;

    private float time = 0;

    private float endingTime = 0;

    private bool ending = false;

    private float initY;
    private float initX;

    private Vector2 dest = new Vector2(-4.96f, -1.2f);

    // Start is called before the first frame update
    void Start()
    {
        initX = transform.position.x;
        initY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.position = new Vector2(initX, initY + 0.1f * Mathf.Cos((time + offset) * Mathf.PI / 2 ));

        if (ending)
        {
            endingTime += Time.deltaTime * 3;
            Vector2 init = transform.position;
            float d = EasingFunc.EaseInBack(endingTime);
            transform.position = init * (1 - d) + dest * d;
        }
    }

    public void StartEnding()
    {
        ending = true;
    }

    
}
