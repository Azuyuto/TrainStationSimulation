using UnityEngine;
using System.IO;

public class SaveJsonFileToDesktop : MonoBehaviour
{
    public string fileName = "cyka"; // The name of the JSON file (without the extension)

    void Start()
    {
        // Create an instance of PlayerData
        PlayerData playerData = new PlayerData
        {
            name = "John Doe",
            age = 30,
            score = 1500
        };

        // Save the data to a JSON file
        SaveDataToJson(playerData, fileName);
    }

    void SaveDataToJson(PlayerData data, string fileName)
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
