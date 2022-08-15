using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class DataBase : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    public void DataCheck()
    {

        string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";
        // Создаем соединение с базой данных
        MySqlConnection mysql_connection = new MySqlConnection(Connect);

        // Создание SQL команды
        MySqlCommand mysql_query = mysql_connection.CreateCommand();
        mysql_query.CommandText = "SELECT * FROM Players;";

        try
        {
            mysql_connection.Open();
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                Debug.Log((mysql_result[0], mysql_result[1], mysql_result[2], mysql_result[3],
                    mysql_result[4], mysql_result[5]));
            }

            mysql_connection.Close();


        }
        catch (Exception err)
        {
            Debug.Log(err.Message);
        }

    }

    public void SaveToDB(string sceneName)
    {

        char x = sceneName[sceneName.Length - 1];
        int z = (int)(x - '0');
        string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";
        //  Создаем соединение с базой данных
        MySqlConnection mysql_connection = new MySqlConnection(Connect);

        //Создание SQL команды
        MySqlCommand mysql_query = mysql_connection.CreateCommand();
        Debug.Log(PlayerInfo.time.ToString() + " --------");
        mysql_query.CommandText = String.Format("UPDATE Players SET levels = {0},  coins = {1}, time = '{2}' WHERE name = '{3}'",
            z + 1, PlayerInfo.coins, PlayerInfo.time.ToString(), PlayerInfo.loginPlayer);
        PlayerInfo.countLevels = z + 1;
        try
        {
            mysql_connection.Open();
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            mysql_connection.Close();


        }
        catch (Exception err)
        {
            Debug.Log(err.Message);
        }


    }
    public void LevelCount()
    {
        int count = 0;

        string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";
        //  Создаем соединение с базой данных
        MySqlConnection mysql_connection = new MySqlConnection(Connect);

        //Создание SQL команды
        MySqlCommand mysql_query = mysql_connection.CreateCommand();
        mysql_query.CommandText = String.Format("SELECT levels FROM Players WHERE name = '{0}'", PlayerInfo.loginPlayer);

        try
        {
            mysql_connection.Open();
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                count =Convert.ToInt32( mysql_result[0] );
            }
            mysql_connection.Close();


        }
        catch (Exception err)
        {
            Debug.Log(err.Message);
        }
        PlayerInfo.countLevels = count;
        Debug.Log(PlayerInfo.countLevels);

    }
    private string HashPassword(string input)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        return Convert.ToBase64String(hash);
    }
    public void AddPlayer(string login, string pass)
    {
        string Connect = "server=dimasoe9.beget.tech;user=dimasoe9_game;database=dimasoe9_game;password=qwe123!";
        //  Создаем соединение с базой данных
        MySqlConnection mysql_connection = new MySqlConnection(Connect);

        //Создание SQL команды
        MySqlCommand mysql_query = mysql_connection.CreateCommand();
        mysql_query.CommandText = String.Format("INSERT INTO Players (name, password) VALUES ('{0}', '{1}')",login, HashPassword(pass));
        try
        {
            mysql_connection.Open();
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            DBConnection dbc = new DBConnection();
            dbc.loginStage.SetActive(true);
            dbc.registerStage.SetActive(false);
            while (mysql_result.Read())
            {
               
            }
            mysql_connection.Close();


        }
        catch (Exception err)
        {
            Debug.Log(err.Message);
        }



    }
}


