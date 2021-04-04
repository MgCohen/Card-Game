using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using System;

public class CardField : MonoBehaviour, IComparable<CardField>
{

    public List<Card> currentCards;

    [HideInInspector]
    public bool locked = false;

    void Awake()
    {
        CardManager.instance.Register(this);
        Lock();
    }

    public virtual void OnPickCard(Card card)
    {

    }

    public virtual void OnDropCard(Card card)
    {

    }

    public virtual void AddCurrentCards(Card card)
    {
        currentCards.Add(card);
        UpdateCards();
    }

    public virtual void RemoveCurrentCards(Card card)
    {
        currentCards.Remove(card);
        UpdateCards();
    }

    public virtual void UpdateCards()
    {
        foreach (var card in currentCards)
        {
            card.GetComponent<CardDrag>().GoTo(transform.position);
        }
    }

    public virtual void Lock()
    {
        locked = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public virtual void Unlock()
    {
        locked = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public int CompareTo(CardField other)
    {
        return 0;
    }

    public virtual bool isAvailable()
    {
        return currentCards.Count == 0;
    }
}

