using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer sprite;
    
    void Update()
    {
        sprite.sortingOrder = -(int)Mathf.Ceil(transform.position.y * 100);
    }
}
