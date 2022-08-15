using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Button2 : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject camera2;
    [SerializeField] GameObject spikes;
    [SerializeField] GameObject frog;
    [SerializeField] Sprite greenSprite;
    private SpriteRenderer sr;
    private float timeNow;

    private void Update()
    {
        Func();
        if (spikes)
        {
            if (spikes.transform.position.y < 18)
            {
                Destroy(spikes);
                Destroy(frog);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

    }
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        camera2.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.name == "MainHero")
        {
            sr.sprite = greenSprite;
            timeNow = Time.time;
            Debug.Log(timeNow);
            mainCamera.SetActive(false);
            camera2.SetActive(true);
            spikes.GetComponent<Rigidbody2D>().simulated = true;
        }

    }
    private void Func()
    {
        float q = Time.time;
        if ((q - timeNow) > 3)
        {
            camera2.SetActive(false);
            mainCamera.SetActive(true);
        }
    }

}
