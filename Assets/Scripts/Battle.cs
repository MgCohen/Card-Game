using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle
{
    public static Inimigo inimigo;
    public static Player player;

    public static Deck deck;

    public static void PlayCard(Card card)
    {
        inimigo.takeDamage((card.atk - inimigo.Def));
        if (inimigo.hp > 0) player.takeDamage((inimigo.Atk - card.def));
        card.Effect();
        deck.Draw();
    }
}
