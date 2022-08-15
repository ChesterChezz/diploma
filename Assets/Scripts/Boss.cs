using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform dot;
    [SerializeField] private Transform hero;
    [SerializeField] private List< GameObject> hearts;
    [SerializeField] private GameObject saw;
    [SerializeField] private GameObject saw2;
    private float timeNow;
    private int lives =3;

    // Start is called before the first frame update
    void Start()
    {
        timeNow = Time.time;
    }
    private void Shoot()
    {
       Instantiate(saw, dot.position, transform.rotation);
    }
   
    void Update()
    {
        if ((Time.time - timeNow) >= 1.5)
        {
            Shoot();
            timeNow = Time.time;
        }
        if(lives == 0)
        {
            Destroy(gameObject);
            Destroy(saw2);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.ToString() == "15")
        {
            lives--;
            Destroy(hearts[3 - (lives+1)]);
            Destroy(collision.gameObject);
        }
    }

}
