﻿using Assets.Scripts.Model;
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
                var rotation = new Quaternion(-1f, 0f, 0f, 1f);
                foreach (var item in DataHelper.trains)
                {
                    GameObject trainInstance = Instantiate(trainPrefab, new Vector3(0, 0, 0), rotation);
                    trainInstance.name = item.Id; // Assign a unique name based on the train ID
                    item.Instance = trainInstance; // Save the reference to the instantiated GameObject in the Train instance
                    
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
            foreach (var item in DataHelper.trains)
            {
                item.X -= item.Speed / 100;
                if(item.X < -20)
                {
                    item.X = 20;
                }
                
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
