using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Lvl5 : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject scene;
    [SerializeField] private GameObject sceneLevel;
    [SerializeField] private GameObject npc;
    [SerializeField] private Camera cam;
    private int sceneCounter;
    [SerializeField] private Button press_Btn;
    [SerializeField] private Animator animHero;
    [SerializeField] private Animator animCamera;
    [SerializeField] private Animator animNPC;
    [SerializeField] private GameObject txt1;
    [SerializeField] private GameObject txt2;
    [SerializeField] private GameObject txt3;
    [SerializeField] private GameObject txt4;
    [SerializeField] private GameObject txt5;
    [SerializeField] private GameObject txt6;
    [SerializeField] private GameObject txt7;
    [SerializeField] private GameObject txt8;
    public void Btn_Press()
    {
        sceneCounter++;
    }
    void Start()
    {

        sceneCounter = 0;

    }
    [System.Obsolete]
    void Update()
    {
        cam.orthographicSize = 5;
        cam.transform.position = new Vector3(0, 0, -10);
        if (Input.GetButtonDown("Jump"))
        {
            sceneCounter++;
        }
        if (sceneCounter == 1)
        {
            //Start Move to center
            animHero.enabled = true;
        }
        if (sceneCounter == 2)
        {
            txt1.active = true;
        }
        if (sceneCounter == 3)
        {
            txt1.active = false;
            txt2.active = true;
        }
        if (sceneCounter == 4)
        {
            txt3.active = true;
            txt2.active = false;
        }
        if (sceneCounter == 5)
        {
            //Camera anim START
            animCamera.enabled = true;
            txt3.active = false;
            txt4.active = true;
        }
        if (sceneCounter == 6)
        {
            txt5.active = true;
            txt4.active = false;
        }
        if (sceneCounter == 7)
        {
            txt6.active = true;
            txt5.active = false;
        }
        if (sceneCounter == 8)
        {
            txt7.active = true;
            txt6.active = false;
        }
        if (sceneCounter == 9)
        {
            txt7.active = false;
            txt8.active = true;
        }
        if (sceneCounter == 10)
        {
            txt8.active = false;
            animHero.Play("Run");

        }
        if (sceneCounter == 11)
        {
            scene.SetActive(false);
            sceneLevel.SetActive(true);
        }
    }

}
