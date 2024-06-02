using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Bench : MonoBehaviour
{
    private int id;
    private float length;
    private int attachedPlatformId;


    GameObject benchObj;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    /// 

    public Bench(int platformId, int benchId, float x, float y, float z, float rotateY, float length, int side)
    {
        id = Convert.ToInt16(Convert.ToString(platformId) + Convert.ToString(benchId));
        attachedPlatformId = platformId;

        this.benchObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.benchObj.transform.position = new Vector3(x, y+2, z);
        this.benchObj.GetComponent<MeshRenderer>().material.color = Color.yellow;
        this.benchObj.GetComponent<MeshRenderer>().name = "Bench " + benchId;
        this.benchObj.transform.localScale = new Vector3((float)2.5, (float)1.5, (float)1.5);
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