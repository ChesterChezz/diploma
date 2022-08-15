using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene_Final_1 : MonoBehaviour
{
    [SerializeField] private Animator hero;
    [SerializeField] private Animator princess;
    [SerializeField] private Animator yoda;
    private int sceneCounter;
    [SerializeField] private Button btn;
    [SerializeField] private GameObject txt1;
    [SerializeField] private GameObject txt2;
    [SerializeField] private GameObject txt3;
    [SerializeField] private GameObject txt4;
    [SerializeField] private GameObject txt5;
    [SerializeField] private GameObject txt6;
    [SerializeField] private GameObject txt7;
    [SerializeField] private GameObject txt8;
    [SerializeField] private GameObject txt9;
    [SerializeField] private GameObject txt10;
    [SerializeField] private GameObject txt11;
    [SerializeField] private GameObject txt12;

    // Start is called before the first frame update
    void Start()
    {
        sceneCounter = 0;
    }
    public void Btn_Press()
    {
  
        sceneCounter++;
    }
    [System.Obsolete]
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            sceneCounter++;
        }
        if (sceneCounter == 1)
        {
            //Start Move to center
            hero.enabled = true;
            princess.enabled = true;
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
            txt3.active = false;
            txt4.active = true;
        }
        if (sceneCounter == 6)
        {
            txt4.active = false;
            txt5.active = true;
        }
        if (sceneCounter == 7)
        {
            txt5.active = false;
            txt6.active = true;
        }
        if (sceneCounter == 8)
        {
            txt6.active = false;
            txt7.active = true;
        }
        if (sceneCounter == 9)
        {
            txt7.active = false;
            txt8.active = true;
        }
        if (sceneCounter == 10)
        {
            txt8.active = false;
            txt9.active = true;
        }
        if (sceneCounter == 11)
        {
            txt9.active = false;
            yoda.enabled = true;
            princess.Play("Fly_Princess");
        }
        if (sceneCounter == 12)
        {

            txt10.active = true;
        }
        if (sceneCounter == 13)
        {
            txt10.active = false;
            txt11.active = true;
        }
        if (sceneCounter == 14)
        {
            txt11.active = false;
            txt12.active = true;
        }
        if (sceneCounter == 15)
        {
            FinishMenu fm = new FinishMenu();
            fm.LoadMenu();
        }
    }
}
