using Assets.Scripts.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class DataHelper
    {
        private static readonly string PlatformsJsonFileName = "platforms";
        private static readonly string TracksJsonFileName = "tracks";
        private static readonly string TrainsJsonFileName = "trains";

        public static List<Model.Platform> Platforms = new List<Model.Platform>();
        public static List<Model.Track> Tracks = new List<Model.Track>();
        public static List<Train> Trains = new List<Train>();

        public static void InitializeData()
        {
            // 1. Platforms
            TextAsset jsonFile = Resources.Load<TextAsset>(PlatformsJsonFileName);
            if (jsonFile != null)
            {
                var x = JsonConvert.DeserializeObject<List<Model.Platform>>(jsonFile.text);
                Platforms = x;
            }

            // 2. Tracks
            jsonFile = Resources.Load<TextAsset>(TracksJsonFileName);
            if (jsonFile != null)
            {
                Tracks = JsonConvert.DeserializeObject<List<Model.Track>>(jsonFile.text);
            }

            // 3. Trains
            jsonFile = Resources.Load<TextAsset>(TrainsJsonFileName);
            if (jsonFile != null)
            {
                Trains = JsonConvert.DeserializeObject<List<Train>>(jsonFile.text);
            }

            AttachModels();
        }

        public static void SaveData()
        {

        }

        private static void AttachModels()
        {
            Trains.ForEach(a => a.ParentTrack = Tracks.FirstOrDefault(c => c.Id == a.ParentTrack.Id));
            Tracks.ForEach(a => a.ParentPlatform = Platforms.FirstOrDefault(c => c.Id == a.ParentPlatform.Id));
            Tracks.ForEach(a => a.Train = Trains.FirstOrDefault(c => c.Id == a.Train.Id));
            Platforms.ForEach(a => a.Tracks = Tracks.Where(c => a.Tracks.Any(d => d.Id == c.Id)).ToList());
        }
    }
}
