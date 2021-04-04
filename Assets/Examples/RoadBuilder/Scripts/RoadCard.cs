using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoadBuilder
{
    public class RoadCard : Card
    {
        public RoadDirections directions;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(directions);
                Debug.Log((int)directions);
                var dir = (int)directions;
                var direc = dir.SplitPOT();

            }
        }
    }

    [System.Flags]
    public enum RoadDirections
    {
        top = 1 << 0,
        left = 1 << 1,
        bot = 1 << 2,
        right = 1 << 3,
        All = top | left | bot | right
    }
}
