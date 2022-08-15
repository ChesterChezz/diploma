using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button5 : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject boss;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MainHero")
        {
            ball.GetComponent<Rigidbody2D>().simulated = true;

            Destroy(gameObject);
        }
    }
}
