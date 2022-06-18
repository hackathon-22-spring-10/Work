using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBehaviour : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = mainCamera.transform.position;
        transform.position = new Vector2(-v.x * 0.019415f, 0);
    }
}
