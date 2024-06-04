using UnityEngine;
using System.IO;
using Assets.Scripts.Model;

public class SaveJsonFileToDesktop : MonoBehaviour
{
    public string fileName = "cyka"; // The name of the JSON file (without the extension)

    void Start()
    {
        // Save the data to a JSON file
        SaveDataToJson(new Train(), fileName);
    }

    void SaveDataToJson(Train data, string fileName)
    {
        // Serialize the data to a JSON string
        string json = JsonUtility.ToJson(data, true);

        // Get the path to the desktop
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

        // Define the full file path
        string filePath = Path.Combine(desktopPath, fileName + ".json");

        // Write the JSON string to the file
        File.WriteAllText(filePath, json);

        Debug.Log("Data saved to " + filePath);
    }
}
