using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Door : MonoBehaviour
{
    [SerializeField] GameObject currentScene;
    [SerializeField] GameObject nextScene;
    [SerializeField] private AudioSource background;
    [SerializeField] private AudioSource careless;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MainHero")
        {
            currentScene.SetActive(false);
            nextScene.SetActive(true);
            background.mute = true;
            careless.Play();
        }
    }
}
