using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class Train
    {
        public GameObject Instance { get; set; }
        public string Id { get; set; }
        public string Color { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float RotateY { get; set; }
        public float Speed { get; set; }
    }
}
