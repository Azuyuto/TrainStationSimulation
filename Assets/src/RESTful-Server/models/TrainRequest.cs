using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.src.RESTful_Server.models
{
    [System.Serializable]
    public class TrainRequest
    {
        public string id;
        public string color;
        public int speed;
    }
}
