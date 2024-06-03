using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string name;
    public int age;
    public int score;
}

public class LoadJsonFile : MonoBehaviour
{
    public string fileName = "blyat"; // The name of the JSON file (without the extension)

    void Start()
    {
        LoadFile(fileName);
    }

    void LoadFile(string fileName)
    {
        // Path to the JSON file in the Resources folder
        TextAsset jsonFile = Resources.Load<TextAsset>(fileName);

        if (jsonFile != null)
        {
            // Parse the JSON file contents
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonFile.text);

            // Use the parsed data
            Debug.Log("Name: " + playerData.name);
            Debug.Log("Age: " + playerData.age);
            Debug.Log("Score: " + playerData.score);
        }
        else
        {
            Debug.LogError("Cannot find JSON file!");
        }
    }
}
