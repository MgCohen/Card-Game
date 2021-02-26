using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : Card
{
    public override void Effect()
    {
        base.Effect();
        foreach(Transform t in Battle.player.hand)
        {
            var card = t.GetComponent<Card>();
            card.atk += 10;
            card.atkValue.text = card.atk.ToString();
        }
    }
}
