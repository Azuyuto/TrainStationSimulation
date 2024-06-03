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
    GameObject table;
    /// <summary>
    /// Use this for initialization
    /// </summary>
    /// 

    public Track(int platformId, int truckId, float x, float y, float z, float rotateY, float length, int side, bool tables)
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

        string tabletext = "Track " + truckId + "platform " + platformId;
        this.table = GameObject.CreatePrimitive(PrimitiveType.Cube);
        this.table.transform.position = new Vector3(x, y + 10, z - 8f * side);
        this.table.GetComponent<MeshRenderer>().material.color = Color.blue;
        this.table.GetComponent<MeshRenderer>().name = "Table: "+tabletext;
        this.table.transform.localScale = new Vector3(1f, 2f, 4f);

        GameObject textObject = new GameObject(tabletext);
        textObject.transform.parent = this.table.transform; 
        textObject.transform.localPosition = new Vector3(0, 1, 0);
        TextMesh textMesh = textObject.AddComponent<TextMesh>();
        textMesh.text = tabletext; // Set the text
        textMesh.fontSize = 12; // Set the font size
        textMesh.alignment = TextAlignment.Center; // Set the alignment
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