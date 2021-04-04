using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardDrag : Draggable
{
    Card card;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    public override void Pick()
    {
        base.Pick();
        card.currentField?.OnPickCard(card);
        CardManager.instance.UnlockTargetFields(card);
        CardManager.OnPickCard.Invoke(card);
    }

    public override void Drop()
    {
        base.Drop();
        card.currentField?.OnDropCard(card);
        var hoveredField = CardManager.instance.GetHoveredField();
        Drop(hoveredField);
    }

    public virtual void Drop(CardField field)
    {
        if (field && field != card.currentField && field.isAvailable())
        {
            RemoveFromField();
            UpdateCurrentField(field);
            AddToField();
        }
        else
        {
            card.currentField?.UpdateCards();
        }
        CardManager.instance.LockFields();
        CardManager.OnDropCard.Invoke(card);
    }


    public void RemoveFromField()
    {
        card.currentField?.RemoveCurrentCards(card);
    }

    public void UpdateCurrentField(CardField field)
    {
        card.currentField = field;
    }

    public void AddToField()
    {
        card.currentField.AddCurrentCards(card);
    }

    public virtual void Lock()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public virtual void Unlock()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }



}
