using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using System.Linq;

public class CardManager : MonoBehaviour
{
    public static Vector3 mousePos => Camera.main.ScreenToWorldPoint(Input.mousePosition);

    public static CardManager instance;

    public Dictionary<string, List<CardField>> fieldList = new Dictionary<string, List<CardField>>();
    [HideInInspector]
    public List<CardField> unlockedFields = new List<CardField>();

    public static UnityEvent<Card> OnPickCard = new UnityEvent<Card>();
    public static UnityEvent<Card> OnDropCard = new UnityEvent<Card>();

    void Awake()
    {
        if (!instance) instance = this;
    }

    private void OnValidate()
    {
        var fieldTypes = Extensions.GetDerivedNames<CardField>();
        foreach (var type in fieldTypes)
        {
            if (!fieldList.ContainsKey(type))
            {
                fieldList.Add(type, new List<CardField>());
            }
        }
    }

    public virtual CardField GetHoveredField()
    {
        var fields = Physics2D.RaycastAll(mousePos, Vector3.forward, 0);
        var field = fields.Select(x => x.transform.GetComponent<CardField>()).FirstOrDefault(y => y != null);
        //return field ? field.transform.GetComponent<CardField>() : null;
        return field;
    }

    public virtual void Register(CardField field)
    {
        var type = field.GetType().Name;
        if (!fieldList.ContainsKey(type))
        {
            fieldList.Add(type, new List<CardField>());
        }
        fieldList[type].Add(field);
    }

    public virtual List<CardField> GetFields(List<string> types)
    {
        List<CardField> fields = new List<CardField>();
        foreach (var s in types)
        {
            fields.AddRange(GetFields(s));
        }
        return fields;
    }

    public virtual List<CardField> GetFields(string type)
    {
        return fieldList[type];
    }

    public virtual List<CardField> GetTargetFields(Card card)
    {
        return GetFields(card.targets);
    }

    public virtual void UnlockTargetFields(Card card)
    {
        var targets = GetTargetFields(card);
        foreach(var t in targets)
        {
            t.Unlock();
            unlockedFields.Add(t);
        }
    }

    public virtual void LockFields()
    {
        foreach(var t in unlockedFields)
        {
            t.Lock();
        }
        unlockedFields.Clear();
    }

}

[System.Flags]
public enum FieldType
{
    A = 1 << 0,
    B = 1 << 1,
    C = 1 << 2,
    All = A | B | C
}
