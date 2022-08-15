using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject hero;
    [SerializeField] private GameObject princess;
    [SerializeField] private GameObject txt1;
    [SerializeField] private GameObject txt2;
    [SerializeField] private GameObject txt3;
    [SerializeField] private GameObject txt4;
    [SerializeField] private GameObject txt5;
    [SerializeField] private GameObject txt6;
    [SerializeField] private GameObject txt7;
    [SerializeField] private Button next_btn;
    private SpriteRenderer heroSR;
    private SpriteRenderer princessSR;
    private int sceneCounter;
    [SerializeField] private Animator animHero;
    [SerializeField] private Animator animPrincess;
    [SerializeField] private Animator animFrogs;
    void Start()
    {
        heroSR = hero.GetComponentInChildren<SpriteRenderer>();
        princessSR = princess.GetComponentInChildren<SpriteRenderer>();
        sceneCounter = 0;
        
    }
    public void Btn_Press()
    {
        sceneCounter++;
    }
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            sceneCounter++;
        }
        if(sceneCounter == 1)
        {
            //Start Move to center
            animHero.enabled = true;
            animPrincess.enabled = true;
        }
        if (sceneCounter == 2)
        {
            txt1.active = true;
            princessSR.flipX = true;
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
            animFrogs.enabled = true;
            animPrincess.Play("pr2");
        }
        if (sceneCounter == 7)
        {
            txt5.active = true;
        }
        if (sceneCounter == 8)
        {
            txt5.active = false;
            txt6.active = true;
        }
        if (sceneCounter == 9)
        {
            txt6.active = false;
            txt7.active = true;
        }
        if (sceneCounter == 10)
        {
            txt7.active = false;
            animHero.Play("hr2");
        }
        if (sceneCounter == 11)
        {
            SceneManager.LoadScene("Level_1_1");
        }
    }
}
