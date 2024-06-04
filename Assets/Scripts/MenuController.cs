using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MenuController : MonoBehaviour
{
    public TMP_InputField inputCiapagi;
    public TMP_InputField inputWagony;
    public TMP_InputField inputPerony;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void LoadLevel(int index)
    {

        //StaticVariables.ciapagi = inputCiapagi.text;
        //StaticVariables.wagony = inputWagony.text;
        //StaticVariables.MAX_NO_PLATFORMS = inputPerony.text;
        //Debug.Log(inputCiapagi.text);
        SceneManager.LoadScene(index);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
