using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Model
{
    public class Track
    {
        [JsonIgnore]
        public GameObject InstanceRailLeft { get; set; }
        [JsonIgnore]
        public GameObject InstanceRailRight { get; set; }
        public Platform ParentPlatform { get; set; }
        public string Id { get; set; }
        public bool IsLeftTrack { get; set; }
        public int Number { get; set; }
        public float Length { get; set; }
        public Train Train { get; set; }

        public Vector3 GetPosition()
        {
            var position = ParentPlatform.GetPosition();
            var halfOfWidth = ParentPlatform.Width / 2;
            position.z += IsLeftTrack ? halfOfWidth + 5 : (-1) * halfOfWidth - 5;

            return position;
        }

        public Vector3 GetRailPosition(bool isLeft)
        {
            var position = GetPosition();
            position.z += isLeft ? 3 : -3;

            return position;
        }

        public float GetRotationY()
        {
            return ParentPlatform.RotateY;
        }
    }
}
