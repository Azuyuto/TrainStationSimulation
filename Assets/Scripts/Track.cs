using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Track : MonoBehaviour
{
    private int id;
    private float length;
    private int attachedPlatformId;


    GameObject rail1;
    GameObject rail2;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    /// 

    public Track(int platformId, int truckId, float x, float y, float z, float rotateY, float length, int side)
    {
        id = Convert.ToInt16(Convert.ToString(platformId) + Convert.ToString(truckId));
        attachedPlatformId = platformId;

        this.rail1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.rail1.transform.position = new Vector3(x, y, z - 8f * side);
        this.rail1.GetComponent<MeshRenderer>().material.color = Color.gray;
        this.rail1.GetComponent<MeshRenderer>().name = "Track " + truckId + " rail 1";
        this.rail1.transform.localScale = new Vector3(120, 1f, 0.5f);

        this.rail2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.rail2.transform.position = new Vector3(x, y, z + 12f * side);
        this.rail2.GetComponent<MeshRenderer>().material.color = Color.gray;
        this.rail2.GetComponent<MeshRenderer>().name = "Track " + truckId + " rail 2";
        this.rail2.transform.localScale = new Vector3(120, 1f, 0.5f);
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