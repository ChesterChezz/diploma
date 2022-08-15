using UnityEngine;
using System.Data;
using System;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;

public class DBConnection : MonoBehaviour
{
   // public SqliteConnection dbconnection;
    public string heroName;
    public int lvlCount;
    private string path;
    [SerializeField] InputField loginField;
    [SerializeField] InputField passwordField;
    [SerializeField] InputField loginField1;
    [SerializeField] InputField passwordField1;
    [SerializeField] GameObject errorText;
    [SerializeField] GameObject loginStageErrorText;
    [SerializeField] public GameObject registerStage;
    [SerializeField] public GameObject loginStage;
    [SerializeField] GameObject mainMenuStage;
    [SerializeField] GameObject leadersStage;
    [SerializeField] GameObject contactUsStage;
    [SerializeField] GameObject levelsStage;
    [SerializeField] GameObject SentSucc;
    [SerializeField] Text hellotxt;
    [SerializeField] Text reportText;
    [SerializeField] Text test;
    [SerializeField] Text top1;
    [SerializeField] Text top2;
    [SerializeField] Text top3;
    [SerializeField] Text top1c;
    [SerializeField] Text top2c;
    [SerializeField] Text top3c;
    [SerializeField] Text top1t;
    [SerializeField] Text top2t;
    [SerializeField] Text top3t;
    [SerializeField] Text myTop;
    [SerializeField] Text myTopC;
    [SerializeField] Text myTopT;
    private void Start()
    {
        try
        {
            if (PlayerInfo.loginPlayer.Length > 0)
            {
                MainMenu();
            }
        }
        catch { }

    }
    public void ContactUs()
    {
        SentSucc.SetActive(false);
        mainMenuStage.SetActive(false);
        loginStage.SetActive(false);
        registerStage.SetActive(false);
        contactUsStage.SetActive(true);
    }
   
    public void SendReport()
    {
        SentSucc.SetActive(false);
        MailMessage message = new MailMessage();
        message.Body = reportText.text;
        message.From = new MailAddress("dimasow12@gmail.com");
        message.To.Add("dimasow12@gmail.com");
        message.BodyEncoding = System.Text.Encoding.UTF8;
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.Credentials = new NetworkCredential(message.From.Address, "NobodyCanStealGaidai12");
        client.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
        client.Send(message);
        SentSucc.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        contactUsStage.SetActive(false);
        loginStage.SetActive(false);
        registerStage.SetActive(false);
        mainMenuStage.SetActive(true);
        hellotxt.text = PlayerInfo.loginPlayer;
    }
    public void LeaderBoard()
    {
        mainMenuStage.SetActive(false);
        leadersStage.SetActive(true);
        Leaders();
    }
    private string  ConvertTime(string text)
    {
        Debug.Log("FUNC");
        text.Replace(',', '.');
        double timed = Convert.ToDouble(text);
        int timeinsec = (int)timed;
        var ts = TimeSpan.FromSeconds(timeinsec);
        string q = String.Format("{0} H {1} M {2} S", ts.Hours, ts.Minutes, ts.Seconds);
        return q;
    }
    void MyTop()
    {
        string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";
        //  Создаем соединение с базой данных
        MySqlConnection mysql_connection = new MySqlConnection(Connect);

        //Создание SQL команды
        MySqlCommand mysql_query = mysql_connection.CreateCommand();
        mysql_connection.Open();
        if (mysql_connection.State == ConnectionState.Open)
        {
            mysql_query.CommandText =String.Format( "SELECT * from Players WHERE name = '{0}'", PlayerInfo.loginPlayer);
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                //Debug.Log(mysql_result[5]);
              
                    myTop.text = "You) " + mysql_result[1].ToString();
                    myTopC.text = mysql_result[5].ToString();
                    myTopT.text = ConvertTime(mysql_result[4].ToString());


            }

        }
        mysql_connection.Close();
    }
    void Leaders()
    {
        int count = 0;
        string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";
        //  Создаем соединение с базой данных
        MySqlConnection mysql_connection = new MySqlConnection(Connect);

        //Создание SQL команды
        MySqlCommand mysql_query = mysql_connection.CreateCommand();
        mysql_connection.Open();
        if (mysql_connection.State == ConnectionState.Open)
        {
            mysql_query.CommandText = "SELECT * from Players ORDER BY coins DESC";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                //Debug.Log(mysql_result[5]);
                if (count == 0)
                {
                    top1.text = "1) " +mysql_result[1].ToString();
                    top1c.text = mysql_result[5].ToString();
                    top1t.text = ConvertTime(mysql_result[4].ToString());

                }
                if (count == 1)
                {
                    top2.text = "2) " + mysql_result[1].ToString();
                    top2c.text = mysql_result[5].ToString();
                    top2t.text = ConvertTime(mysql_result[4].ToString());
                }
                if (count == 2)
                {
                    top3.text = "3) " + mysql_result[1].ToString();
                    top3c.text = mysql_result[5].ToString();
                    top3t.text = ConvertTime(mysql_result[4].ToString());
                }
                count++;
                if (count == 3)
                {
                    break;
                }

            }
            
        }
        mysql_connection.Close();
        MyTop();
    }
    public void LogIn()
    {

        string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";
        //  Создаем соединение с базой данных
        MySqlConnection mysql_connection = new MySqlConnection(Connect);

        //Создание SQL команды
        MySqlCommand mysql_query = mysql_connection.CreateCommand();
        mysql_connection.Open();
        if (mysql_connection.State == ConnectionState.Open)
        {
            mysql_query.CommandText = "SELECT * from Players";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                if (mysql_result[1].ToString() == loginField1.text && mysql_result[2].ToString() == HashPassword(passwordField1.text))
                {
                    Debug.Log(loginField1.text + " WITH PASS : " + passwordField1.text + " LOGGINED IN !");
                    PlayerInfo.loginPlayer = loginField1.text;
                    PlayerInfo.countLevels = Int32.Parse(mysql_result[3].ToString());
                    PlayerInfo.time = (float)Convert.ToDouble(mysql_result[4].ToString());
                    PlayerInfo.coins = Int32.Parse(mysql_result[5].ToString());
                    loginStage.SetActive(false);
                    registerStage.SetActive(false);
                    mainMenuStage.SetActive(true);
                    MainMenu();
                    break;
                }
                else
                {
                    Debug.Log("Error (((( ");
                    loginStageErrorText.SetActive(true);
                }
            }
        }


    }
    private string HashPassword(string input)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(hash);
    }
    public void AddPlayer()
    {
       bool check = false;
       if(loginField.text.Length >= 3 && loginField.text.Length <= 10)
        {
            if (passwordField.text.Length >= 3 && passwordField.text.Length <= 10)
            {
                string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";

                // Создаем соединение с базой данных
                MySqlConnection mysql_connection = new MySqlConnection(Connect);

                //Создание SQL команды
                MySqlCommand mysql_query = mysql_connection.CreateCommand();
                mysql_query.CommandText = String.Format("INSERT INTO Players (name, password) VALUES ('{0}', '{1}')", loginField.text, HashPassword(passwordField.text));
                try
                {
                    mysql_connection.Open();
                    MySqlDataReader mysql_result;
                    mysql_result = mysql_query.ExecuteReader();
                    loginStage.SetActive(true);
                    registerStage.SetActive(false);
                    while (mysql_result.Read())
                    {

                    }
                    mysql_connection.Close();

                    check = true;
                }
                catch (Exception err)
                {
                    Debug.Log(err.Message);
                    errorText.SetActive(true);
                }
            }
        }
        if (check == false)
        {
            test.text = "login must be  between 3 and 10 characters...\n password must be between 3 and 10 characters...";
        }
       
    }
    public void RegisterStage()
    {
        registerStage.SetActive(true);
        loginStage.SetActive(false);
        loginStageErrorText.SetActive(false);
    }
    public void LevelStage()  //HERE !!!!
    {
        DataBase db = new DataBase();
        db.LevelCount();
        
        levelsStage.SetActive(true);
        registerStage.SetActive(false);
        loginStage.SetActive(false);
        loginStageErrorText.SetActive(false);
        mainMenuStage.SetActive(false);

    }
}
