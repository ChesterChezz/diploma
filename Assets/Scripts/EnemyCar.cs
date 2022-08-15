using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private bool path;
    public float speed;
    public float default_;
    // Start is called before the first frame update
    void Start()
    {

        speed = 1f;
        default_ = speed;

        if (transform.position.x > 271)
        {
            path = false;
        }
        else
            path = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        CheckPause();
        CheckPath();
        Move();
    }
    private void CheckPause()
    {
        if (PauseMenu.GameIsPaused)
        {
            speed = 0f;
        }
        else
            speed = default_;
    }
    private void CheckPath()
    {
        if (transform.position.x > 1390)
        {
            path = false;

        }
        if (transform.position.x < 800)
        {
            path = true;

        }
     
    }

    private void Move()
    {
        if (!path)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, -2759);
            transform.rotation = Quaternion.Euler(Vector3.forward * 23.471f);
        }
        if(path)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, -2759);
            transform.rotation = Quaternion.Euler(Vector3.forward * -157.529f);
        }
    }
}
