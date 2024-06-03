using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InputFieldManager : MonoBehaviour
{
    // Reference to the TMP_InputField component
    public TMP_InputField inputCiapagi;
    public TMP_InputField inputPerony;
    public TMP_InputField inputWagony;


    // This method will be called to get the input field value
    public void GetInputFieldValue()
    {
        // Get the text value from the input field
        StaticVariables.ciapagi = inputCiapagi.text;
        StaticVariables.MAX_NO_PLATFORMS = Int32.Parse(inputPerony.text);
        StaticVariables.wagony = inputWagony.text;
    }
}