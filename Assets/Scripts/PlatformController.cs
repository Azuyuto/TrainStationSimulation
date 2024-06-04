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
            item.InstanceText = GameObject.CreatePrimitive(PrimitiveType.Cube);
            item.InstanceTextLabel = new GameObject("Peron " + item.Number);

            item.InstanceText.GetComponent<MeshRenderer>().material.color = Color.black;
            item.InstanceText.GetComponent<MeshRenderer>().name = item.Id + "Text";
            item.InstanceText.transform.localScale = new Vector3(6f, 2f, 1f);

            TextMesh textMesh = item.InstanceTextLabel.AddComponent<TextMesh>();
            textMesh.text = item.InstanceTextLabel.name;
            textMesh.fontSize = 12;
            textMesh.alignment = TextAlignment.Center;
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

                var position = item.GetPosition();
                position.y += 10;
                item.InstanceText.transform.position = position;
                item.InstanceTextLabel.transform.parent = item.InstanceText.transform;
                item.InstanceTextLabel.transform.localPosition = new Vector3((float)-0.33, (float)0.33, 0);
            }
        }
    }
}
