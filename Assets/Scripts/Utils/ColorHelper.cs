using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    static public class ColorHelper
    {
        static public bool TryGetColorByName(string colorName, out Color color)
        {
            switch (colorName.ToLower())
            {
                case "red":
                    color = Color.red;
                    break;
                case "green":
                    color = Color.green;
                    break;
                case "blue":
                    color = Color.blue;
                    break;
                case "white":
                    color = Color.white;
                    break;
                case "black":
                    color = Color.black;
                    break;
                case "yellow":
                    color = Color.yellow;
                    break;
                case "cyan":
                    color = Color.cyan;
                    break;
                case "magenta":
                    color = Color.magenta;
                    break;
                case "gray":
                case "grey":
                    color = Color.gray;
                    break;
                default:
                    if (!ColorUtility.TryParseHtmlString(colorName, out color))
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }
    }
}
