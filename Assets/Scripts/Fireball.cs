using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Card
{

    public override void Effect()
    {
        Battle.inimigo.takeDamage(10);
    }
}
