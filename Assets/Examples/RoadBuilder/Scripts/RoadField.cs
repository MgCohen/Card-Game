using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoadBuilder
{
    public class RoadField : CardField
    {
        public override void OnDropCard(Card card)
        {
            base.OnDropCard(card);
            card.drag.Lock();
        }
    }
}

