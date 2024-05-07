using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class Platform : MonoBehaviour
{
    public static int wagoniki = 0;
    private int platformId;
    private float x;
    private float y;
    private float z;
    private float rotateY;
    private Track[] tracks;
    private int maxTrucksNumber;
    private Color color;
    private float length;

    GameObject platformObject;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    /// 

    public Platform(int id, float x, float y, float z, float rotateY, float length)
    {
        this.platformId = id;
        this.x = x;
        this.y = y;
        this.z = z;
        this.rotateY = rotateY;
        this.tracks = new Track[2];
        this.length = length;

        this.platformObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.platformObject.transform.position = new Vector3(x, y, z);
        this.platformObject.GetComponent<MeshRenderer>().material.color = this.color;
        this.platformObject.GetComponent<MeshRenderer>().name = "Platform " + platformId;
        this.platformObject.transform.localScale = new Vector3(60, 3f, 10);

        CreateTrack();
        // CreateTrack();
    }

    void CreateTrack()
    {
        //if(tracks.Length)
        //if (tracks[0].Equals(null))
        //{
        tracks[0] = new Track(this.platformId, 0, this.x, this.y, this.z + 1, 0, this.length, 1);
        // return;
        //}
        //if (tracks[1].Equals(null))
        //{
        tracks[1] = new Track(this.platformId, 1, this.x, this.y, this.z - 1, 0, this.length, -1);
        //  return;
        // }
        // else
        //{
        //no more tracks
        // }

    }

    void RemoveTrack(int trackNumber)
    {
        if (trackNumber.Equals(1) || trackNumber.Equals(2))
        {
            tracks[trackNumber] = null;
        }
    }
    void Start()
    {

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }
}