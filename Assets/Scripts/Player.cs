using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private void OnEnable()
    {
        Battle.player = this;
        hptext.text = Hp.ToString();
    }

    public int Hp;

    public TextMeshProUGUI hptext;

    public Transform hand;

    public void takeDamage(int amount)
    {
        Hp -= amount;
        hptext.text = Hp.ToString();
        if (Hp <= 0)
        {
            //battle chamar novo inimigop
        }
    }
}
