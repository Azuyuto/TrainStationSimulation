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
    private Track[] tracks2;
    private Bench[] benches;
    private int maxTrucksNumber=StaticVariables.MAX_NO_PLATFORMS*2;
    private Color color;
    private float length;
    private int noPlatforms = 0;
    private int noBenchesOnPlatform = 0;

    private GameObject[] platforms;
    GameObject platform1Object;
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
        this.tracks = new Track[maxTrucksNumber];
        this.benches = new Bench[maxTrucksNumber];
        this.platforms = new GameObject[StaticVariables.MAX_NO_PLATFORMS];
        this.length = length;

        for (int i = 0; i < StaticVariables.MAX_NO_PLATFORMS; i++)
        {
            platforms[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platforms[i].transform.position = new Vector3(x, y, z + 30 * noPlatforms);
            platforms[i].GetComponent<MeshRenderer>().material.color = this.color;
            platforms[i].GetComponent<MeshRenderer>().name = "Platform " + noPlatforms;
            platforms[i].transform.localScale = new Vector3(60, 3f, 10);
            noPlatforms++;
            CreateBenches(x, y, z + 30 * noPlatforms, 2);
        }

        CreateTrack(true);//tracks with tables
    }

    void CreateTrack(bool tables)
    {
        //if(tracks.Length)
        //if (tracks[0].Equals(null))
        //{
        for(int i = 0;i< noPlatforms; i++)
        {
            tracks[i] = new Track(this.platformId, 0, this.x, this.y, this.z + 1+i*30, 0, this.length, 1, tables);
            tracks[i+1] = new Track(this.platformId, 1, this.x, this.y, this.z - 1 + i * 30, 0, this.length, -1, tables);
        }

    }

    void CreateBenches(float x, float y, float z, int noBenches)
    {
        int distrance = 15;
        //if(tracks.Length)
        //if (tracks[0].Equals(null))
        //{
        for (int i = 0; i < noBenches; i++)
        {
            benches[i] = new Bench(this.platformId, ++noBenchesOnPlatform, x+(i* distrance + 1), y, z - 1 - 30, 0, this.length/ noBenches, 1);
            benches[i+1] = new Bench(this.platformId, ++noBenchesOnPlatform, x - (i * distrance + 1), y, z - 1 - 30, 0, this.length / noBenches, 1);
        }

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