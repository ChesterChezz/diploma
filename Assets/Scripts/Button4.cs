using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button4 : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject btn;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MainHero")
        {
            ball.GetComponent<Rigidbody2D>().simulated = true;
            btn.SetActive(true);
            Destroy(gameObject);
        }
    }
}
