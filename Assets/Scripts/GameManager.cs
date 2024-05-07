using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Time settings")]
    public TextMeshProUGUI timeText;
    public float time = 0f;


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

        time += Time.deltaTime;
        timeText.text = "Time: " + Mathf.Clamp(Mathf.CeilToInt(time), 0, int.MaxValue).ToString();



        if (time > 999)
        {
            RestartLevel();
        }


    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
