using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed = 5f;
   [SerializeField] private Joystick joystick;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.name == "MainHero")
        {
            if (Input.GetAxis("Vertical") > 0f || joystick.Vertical > 0)
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
               
            }
            else if (Input.GetAxis("Vertical") < 0f || joystick.Vertical < 0)
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else
            {
                collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
