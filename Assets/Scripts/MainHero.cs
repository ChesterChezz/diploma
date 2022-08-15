using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Scripting;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

[assembly: Preserve]

public class MainHero : MonoBehaviour
{


    public float speed = 6f;
    private Animator anim;
    public List<GameObject> hearts;
    public int lives = 3;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = false;
    public LayerMask groundLayer;
    public LayerMask waterLayer;
    public LayerMask afk_Enemy;
    public LayerMask checkPoint;
    public LayerMask finishMask;
    public LayerMask jumperMask;
    public Transform groundCheckCollider;
    public Transform headCheckDot;
    public AudioSource jumpSound;
    public AudioSource damageSound;
    public Material defaultMaterial;
    public Material darkMaterial;
    private Vector3 startPos;
    public GameObject finishMenuUI;
    public GameObject restart;
    public UnityEngine.UI.Text timeText;
    public UnityEngine.UI.Text coinsText;
    public float timeStart;
    private bool timerCheck;
    public int coins;
    public Joystick joystick;
    public GameObject button_jump;
    // [SerializeField] public SqliteConnection dbconnection;


    private void CheckMaterial()
    {
        if(SceneManager.GetActiveScene().name == "Level_1_1")
        {
            if (transform.position.x > 77 && transform.position.x < 152)
            {
                sr.material = darkMaterial;
            }
            else
                sr.material = defaultMaterial;
        }

    }
    // Start is called before the first frame update
    private void Spawn()
    {
        rb.velocity = new Vector2(0, 0);
        damageSound.Play();
        transform.position = startPos;
    }
    private void SaveToDB()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        DataBase db = new DataBase();
        db.SaveToDB(sceneName);

    }
    private void CheckFinish()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, finishMask);
        if (collider.Length > 0)
        {
            timerCheck = false;
            PlayerInfo.time += timeStart;
            PlayerInfo.coins += coins;
            SaveToDB();
            Time.timeScale = 0.0f;
            finishMenuUI.SetActive(true);

        }
    }
    private void isWater()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, waterLayer);
        if (collider.Length > 0)
        {
            
            Spawn();
        }
       
    }
    private void CheckPoint()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, checkPoint);
        if (collider.Length > 0)
        {
            startPos = transform.position;
        }
    }

    private void CheckRestart()
    {
        if(lives == 0)
        {
            FinishMenu fm = new FinishMenu();
            fm.RestartLevel();
        }
    }
    private void Damage()
    {
        
        lives--;
        Destroy(hearts[3 - (lives + 1)]);
    }
    public void AddCoin()
    {
        coins=1;
        Debug.Log("coin");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coins++;
            Destroy(collision.gameObject);
        }
    }
    void Start()
    {
        coins = 0;
        timerCheck = true;
        timeText.text = timeStart.ToString();
        startPos = transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
       // Debug.Log(transform.position.ToString());
        CheckPoint();
        AfkEnemy();
        //jumpForce = 1.53f;
        isWater();
        CheckMaterial();
        CheckFinish();
        CheckJumper();
        CheckRestart();
    }
    void Update()
    {
       
        coinsText.text = coins.ToString();
        if (timerCheck)
        {
            timeStart += Time.deltaTime;
            timeText.text = timeStart.ToString("F2");
        }

        if (isGrounded) State = States.idle;
        CheckVelocity();
        CheckGround();
        if (joystick.Horizontal > 0 || joystick.Horizontal < 0)
        {
            Run();
            button_jump.SetActive(true);
            
        }
        if (Input.GetButton("Horizontal"))
        {
            Run();
            button_jump.SetActive(false);

        }
        if ((isGrounded && Input.GetButton("Jump")) || (Input.GetKeyDown(KeyCode.Space) && isGrounded))
        {
            Jump();

           
        }
    }
    public void JoystickJump()
    {
        if (isGrounded)
        {
            Jump();

        }
    }
    private void AfkEnemy()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.5f, afk_Enemy);
        Collider2D[] collider2 = Physics2D.OverlapCircleAll(headCheckDot.position, 0.5f, afk_Enemy);
        if (collider.Length > 0 || collider2.Length > 0)
        {
            Spawn();
            if (SceneManager.GetActiveScene().name == "Level_1_5")
            {
                Damage();
                Spawn();
            }
        }
            
    }
        void CheckVelocity()
    {
        if (rb.velocity.y < -40f)
        {
            rb.velocity = new Vector2(0, -25);
        }

    }
    private void Run()
    {
        Vector3 dir = new Vector3();
        if (isGrounded) State = States.run;
        if (joystick.Horizontal > 0 || joystick.Horizontal < 0)
        {
             dir = transform.right * joystick.Horizontal;
            

        }
        if (Input.GetButton("Horizontal"))
        {
             dir = transform.right * Input.GetAxis("Horizontal");

        }

        transform.position = Vector3.MoveTowards(transform.position,
            transform.position + dir, speed * Time.deltaTime);
        sr.flipX = dir.x < 0.0f;
    }
    private void Jump()
    {
       
        if(isGrounded)
            rb.velocity = new Vector2(0, 12.5f);
        State = States.jump;
        isGrounded = false;
        jumpSound.Play();
        // rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, groundLayer);
        if (collider.Length > 0)
            isGrounded = true;
        else
        {
            isGrounded = false;
            State = States.jump;
        }
    }

    private void CheckJumper()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, 0.2f, jumperMask);
        if (collider.Length > 0)
        {
            jumpSound.Play();
            isGrounded = false;
            rb.velocity = new Vector2(0, 20.5f);
        }
           
       
    }

    public enum States
    {
        idle,
        run,
        jump
    }
    private States State
    {
        get { return (States)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }

}
