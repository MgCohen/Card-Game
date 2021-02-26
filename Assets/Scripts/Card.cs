using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    public int atk;
    public int def;

    public TextMeshProUGUI atkValue;
    public TextMeshProUGUI defvalue;

    private void OnEnable()
    {
        atkValue.text = atk.ToString();
        defvalue.text = def.ToString();
    }

    public virtual void Effect()
    {

    }

}
