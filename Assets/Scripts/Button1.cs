using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] GameObject ladder;
    [SerializeField] Sprite greenSprite;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "MainHero")
        {
            sr.sprite = greenSprite;
            ladder.transform.position = new Vector3(ladder.transform.position.x , 2.8f, ladder.transform.position.z);
        }
    }
}
