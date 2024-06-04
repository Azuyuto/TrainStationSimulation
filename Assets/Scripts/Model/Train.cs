using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

namespace Assets.Scripts.Model
{
    public class Train
    {
        [JsonIgnore]
        public GameObject Instance { get; set; }
        public Track ParentTrack { get; set; }
        public string Id { get; set; }
        public string Color { get; set; }
        public float Speed { get; set; }
        public float ArrivedLength { get; set; }
        [JsonIgnore]
        public bool ToDelete { get; set; }
        [JsonIgnore]
        public bool ToAdd { get; set; }

        public Vector3 GetPosition()
        {
            var position = ParentTrack.GetPosition();
            position.y += (float)0.2;
            position.x += ArrivedLength;

            return position;
        }

        public float GetRotationY()
        {
            return ParentTrack.GetRotationY();
        }
    }
}
