using UnityEngine;
using System.Collections;

public class TrackController : MonoBehaviour
{
    private int platformsCounter;
    const int MAX_NO_PLATFORMS = 5;
    private int tracksCounter;

    Platform[] platforms;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    /// 

    void AddPlatform(int id, float x, float y, float z, float rotateY, float length)
    {
        if (platformsCounter < MAX_NO_PLATFORMS)
        {
            platforms[platformsCounter] = new Platform(id, x, y, z, rotateY, length);
            platformsCounter++;
        }
    }

    void Start()
    {
            Test();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
    }

    void Test()
    {
        AddPlatform(1, 3, 2, 3, 0, 0);
    }
}