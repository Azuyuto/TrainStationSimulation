using UnityEngine;
using System.Collections;
using Assets.Scripts.Utils;
using Assets.Scripts.Model;

namespace Assets.Scripts
{
    public class TrackController : MonoBehaviour
    {
        void Start()
        {
            foreach (var item in DataHelper.Tracks)
            {
                AddTrack(item);
            }
        }

        public void AddTrack(Model.Track item)
        {
            item.InstanceRailLeft = GameObject.CreatePrimitive(PrimitiveType.Cube);
            item.InstanceRailRight = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }

        void Update()
        {
            foreach (var item in DataHelper.Tracks)
            {
                item.InstanceRailLeft.transform.position = item.GetRailPosition(true);
                item.InstanceRailLeft.GetComponent<MeshRenderer>().material.color = Color.gray;
                item.InstanceRailLeft.GetComponent<MeshRenderer>().name = item.Id + "l";
                item.InstanceRailLeft.transform.localScale = new Vector3(item.Length, 1f, 0.5f);

                item.InstanceRailRight.transform.position = item.GetRailPosition(false);
                item.InstanceRailRight.GetComponent<MeshRenderer>().material.color = Color.gray;
                item.InstanceRailRight.GetComponent<MeshRenderer>().name = item.Id + "r";
                item.InstanceRailRight.transform.localScale = new Vector3(item.Length, 1f, 0.5f);
            }
        }

    }
}