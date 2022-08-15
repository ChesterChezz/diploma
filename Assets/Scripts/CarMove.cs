using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    [SerializeField] GameObject done;
    [SerializeField] Text countOfFruits;
    public int countFruits;
   // public SqliteConnection dbconnection;
    private string path;
    [SerializeField] private LayerMask afk_Enemy;
    [SerializeField] private LayerMask fruits;
    [SerializeField] private LayerMask checkPoint;
    [SerializeField] List<Transform> checkDot;
    [SerializeField] List<GameObject> texts;
    [SerializeField] GameObject boost;
    [SerializeField] private GameObject finishMenuUI;
    [SerializeField] AudioSource crush;
   // [SerializeField] Button right_btn;
    [SerializeField] Joystick joystick;
    [SerializeField] Joystick joystick2;
    // [SerializeField] Button left_btn;
    public float speed;
    public float default_;
    public bool finished;
    Vector3 startPos;
    private void FruitsCounter()
    {
        countOfFruits.text = countFruits.ToString();
        if(countFruits == 5)
        {
            foreach(var x in texts)
            {
                Destroy(x);
                done.SetActive(true);
            }
        }
    }
    
    void Start()
    {
        
        countFruits = 0;
        finished = false;
        speed = 1.3f;
        default_ = speed;
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        FruitsCounter();
        CheckLeft();
        CheckPause();
        CheckPoint();
        Ride();
        AfkEnemy();
        if (Input.GetButton("Horizontal") || joystick.Horizontal != 0)
        {
            MoveToSide();
        }
        if (Input.GetButton("Vertical") || (joystick2.Horizontal != 0 || joystick2.Vertical != 0))
        {

            MoveForward();

        }
       
    }
    private  void CheckPause() 
    {
        if (PauseMenu.GameIsPaused)
        {
            speed = 0f;
        }
        else if (finished)
        {
            speed = 0f;
        }
        else
            speed = default_;
    }
    private void FixedUpdate()
    {
        boost.SetActive(false);
    }
    private void MoveForward()
    {
    
            transform.position = new Vector3(transform.position.x, transform.position.y + speed , -2840);
            boost.SetActive(true);


    }

    private void Ride()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y+speed, -2840);
       
       
    }
    private void MoveToSide()
    {
        if(Input.GetAxis("Horizontal") < 0f || joystick.Horizontal < 0f)
        {
            transform.position = new Vector3(transform.position.x - 1.75f, transform.position.y, -2840);
           // Debug.Log(joystick.Horizontal);
        }
        else if (Input.GetAxis("Horizontal") > 0f || joystick.Horizontal > 0f)
            transform.position = new Vector3(transform.position.x + 1.75f, transform.position.y, -2840);

    }
    private void AfkEnemy()
    {
        Collider2D[] collider;
        foreach (var x in checkDot)
        {
           collider = Physics2D.OverlapCircleAll(x.position, 0.5f, afk_Enemy);
            if (collider.Length > 0)
            {
                Spawn();
            }
        }

    }
   private void CheckLeft()
    {
        if(transform.position.x < 270)
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y, -2840);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Fruit")
        {
            countFruits++;
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Finish")
        {
            DataBase db = new DataBase();
            db.SaveToDB(SceneManager.GetActiveScene().name);
            finished = true;
            Debug.Log(1);
            Time.timeScale = 0f;
            speed = 0f;
            finishMenuUI.SetActive(true);
        }

    }
    private void CheckPoint()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(checkDot[1].position, 0.2f, checkPoint);
        if (collider.Length > 0)
        {
            startPos = transform.position;
        }
    }
    private void Spawn()
    {
        crush.Play();
        transform.position = startPos;
    }
}
