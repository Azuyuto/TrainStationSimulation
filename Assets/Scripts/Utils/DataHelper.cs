using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Utils
{
    public static class DataHelper
    {
        public static List<Train> trains = new List<Train>() {
            new Train() {
                Id = "c1",
                Color = "blue",
                X = 0,
                Y = 5,
                Z = 10,
                RotateY = 0,
                Speed = 1
            },
            new Train() {
                Id = "c2",
                Color = "green",
                X = 0,
                Y = 5,
                Z = -10,
                RotateY = 0,
                Speed = 2
            }
        };
    }
}
