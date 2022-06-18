using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Collider2D col;
    [SerializeField] private float bonusPoint;
    [SerializeField] private ParticleSystem particle;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = sprites[(int)Random.Range(0, 2)];
        particle.Play();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RealPlayer"))
        {
            StartCoroutine(EarnBonus());
        }
    }

    private IEnumerator EarnBonus()
    {
        col.enabled = false;
        FindObjectOfType<Girl>().favorability += bonusPoint;
        while (spriteRenderer.color.a >= 0)
        {
            spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - (3f * Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
