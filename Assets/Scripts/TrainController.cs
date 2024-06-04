using Assets.Scripts.Model;
using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    public class TrainController : MonoBehaviour
    {
        public GameObject trainPrefab;

        void Start()
        {
            if (trainPrefab != null)
            {
                foreach (var item in DataHelper.Trains)
                {
                    AddTrain(item);
                }
            }
            else
            {
                Debug.LogError("Train prefab is not assigned!");
            }
        }

        public void AddTrain(Train item)
        {
            var rotation = new Quaternion(-1f, 0f, 0f, 1f);
            GameObject trainInstance = Instantiate(trainPrefab, new Vector3(0, 0, 0), rotation);
            trainInstance.name = item.Id; // Assign a unique name based on the train ID
            item.Instance = trainInstance; // Save the reference to the instantiated GameObject in the Train instance
        }

        void Update()
        {
            foreach (var item in DataHelper.Trains)
            {
                item.ArrivedLength -= item.Speed / 100;
                if(item.ArrivedLength < (item.ParentTrack.Length / 2) * (-1))
                {
                    item.ArrivedLength = item.ParentTrack.Length / 2;
                }
                
                item.Instance.transform.position = item.GetPosition();

                Color trainColor;
                if (ColorHelper.TryGetColorByName(item.Color, out trainColor))
                {
                    MeshRenderer[] meshRenderers = item.Instance.GetComponentsInChildren<MeshRenderer>();
                    foreach (MeshRenderer meshRenderer in meshRenderers)
                    {
                        meshRenderer.material.color = trainColor;
                    }
                }
            }
        }
    }
}
