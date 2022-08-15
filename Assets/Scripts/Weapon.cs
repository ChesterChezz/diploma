using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{


    public Rigidbody2D rb;
    private GameObject hero;
    private void Start()
    {
        hero = GameObject.Find("MainHero");

        Vector2 fire = new Vector2(hero.transform.position.x -9.5f, hero.transform.position.y+4.8f);

        GetComponent<Rigidbody2D>().AddForce(fire, ForceMode2D.Impulse);
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer.ToString() == "3")
        {
            Destroy(gameObject);
        }

    }
}
