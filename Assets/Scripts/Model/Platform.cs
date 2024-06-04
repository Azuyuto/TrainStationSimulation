using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [System.Serializable]
    public class Platform
    {
        public GameObject Instance { get; set; }
        public string Id { get; set; }
        public string Color { get; set; }
        public int Number { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float RotateY { get; set; }
        public List<Track> Tracks { get; set; }

        public Platform()
        {
            Tracks = new List<Track>();
        }

        public Vector3 GetPosition()
        {
            return new Vector3(X, Y, Z);
        }

        public float GetRotationY()
        {
            return RotateY;
        }
    }
}
