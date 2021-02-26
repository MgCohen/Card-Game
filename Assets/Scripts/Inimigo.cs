using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Inimigo : MonoBehaviour
{

    private void OnEnable()
    {
        Battle.inimigo = this;
        hptext.text = hp.ToString();
    }

    public int hp;

    public int Atk;
    public int Def;

    public TextMeshProUGUI hptext;

    public void takeDamage(int amount)
    {
        hp -= amount;
        hptext.text = hp.ToString();
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
