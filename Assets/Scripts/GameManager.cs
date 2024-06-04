using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    [Header("Time settings")]
    public TextMeshProUGUI timeText;
    //public float time = 0f;
    public string date;
    public string time;
    DateTime theTime = DateTime.Now;
    // Start is called before the first frame update

    private void Awake()
    {
        Time.timeScale = 1f;
        

    }


    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SceneManager.LoadScene(0);

        }
        string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
        //Debug.Log(date);
        string time = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        //Debug.Log(time);
        //time += Time.deltaTime;
        //timeText.text = "Time: " + Mathf.Clamp(Mathf.CeilToInt(time), 0, int.MaxValue).ToString();
        timeText.text = " Date: " + date + "                                                           Time: " + time;


        //if (time > 999)
        //{
        //    RestartLevel();
        //}


    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
