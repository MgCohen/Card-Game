using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


[RequireComponent(typeof(CardDrag))]
public class Card : MonoBehaviour
{
    [HideInInspector] public CardField currentField;
    [HideInInspector] public CardDrag drag;
    [HideInInspector] public CardBody body;

    [ValueDropdown("GetFieldTypes", IsUniqueList = true)]
    public List<string> targets = new List<string>();
    IEnumerable<string> GetFieldTypes()
    {
        return Extensions.GetDerivedNames<CardField>();
    }


    private void Awake()
    {
        drag = GetComponent<CardDrag>();
        body = GetComponent<CardBody>();
    }

    public virtual void Play()
    {

    }

}
