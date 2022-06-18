using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusItemManager : MonoBehaviour
{
    [SerializeField] GameObject bonusItem;
    [SerializeField] private float cooltime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateBonusItem());
    }

    private IEnumerator GenerateBonusItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(cooltime);
            Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, 0));
            pos = new Vector2(pos.x, Random.Range(1f, 5f) * -1);
            Instantiate(bonusItem, pos, Quaternion.identity);
        }
    }
}
