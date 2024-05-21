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
        public List<Train> trains = new List<Train>() { 
            new Train() { 
                Id = "Ciapąg 1",
                Color = "blue",
                X = 0,
                Y = 5,
                Z = 10,
                RotateY = 0,
                Speed = 1
            },
            new Train() {
                Id = "Ciapąg 2",
                Color = "green",
                X = 0,
                Y = 5,
                Z = -10,
                RotateY = 0,
                Speed = 2
            } 
        };

        public GameObject trainPrefab;

        void Start()
        {
            if (trainPrefab != null)
            {
                var rotation = new Quaternion(-1f, 0f, 0f, 1f);
                foreach (var item in trains)
                {
                    item.Instance = Instantiate(trainPrefab, new Vector3(0, 0, 0), rotation);
                }
            }
            else
            {
                Debug.LogError("Train prefab is not assigned!");
            }
        }

        void Update()
        {
            var rotation = new Quaternion(-1f, 0f, 0f, 1f);
            foreach (var item in trains)
            {
                item.X -= item.Speed / 100;
                if(item.X < -20)
                {
                    item.X = 20;
                }
                item.Instance.name = item.Id;
                item.Instance.transform.position = new Vector3(item.X, item.Y, item.Z);
                rotation.y = item.RotateY;
                item.Instance.transform.rotation = rotation;

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
