using Assets.Scripts.Model;
using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlatformController : MonoBehaviour
    {
        void Start()
        {
            foreach (var item in DataHelper.Platforms)
            {
                AddPlatform(item);
            }
        }

        public void AddPlatform(Model.Platform item)
        {
            item.Instance = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }

        void Update()
        {
            foreach (var item in DataHelper.Platforms)
            {
                item.Instance.transform.position = item.GetPosition();
                item.Instance.transform.localScale = new Vector3(item.Length, item.Height, item.Width);
                item.Instance.GetComponent<MeshRenderer>().name = item.Id;

                Color platformColor;
                if (ColorHelper.TryGetColorByName(item.Color, out platformColor))
                {
                    MeshRenderer[] meshRenderers = item.Instance.GetComponentsInChildren<MeshRenderer>();
                    foreach (MeshRenderer meshRenderer in meshRenderers)
                    {
                        meshRenderer.material.color = platformColor;
                    }
                }
            }
        }
    }
}
