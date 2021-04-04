using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public CardField holder;


    public List<Transform> waypoints;
    Vector3[] path => waypoints.Select(x => x.transform.position).ToArray();


    private void Start()
    {
        Draw();
        Invoke(nameof(Draw), 0.5f);
        Invoke(nameof(Draw), 1f);
    }

    public virtual void SetDeck(List<Card> _cards)
    {
        cards.Clear();
        cards = _cards;
        foreach(var c in cards)
        {
            c.gameObject.SetActive(false);
        }
    }

    public virtual void Draw()
    {
        if(cards.Count <= 0)
        {
            OnEmptyDeck();
            return;
        }
        var card = cards[0];
        cards.Remove(card);
        card.transform.position = transform.position;
        card.gameObject.SetActive(true);

        card.body.Flip(true, false);
        card.body.Flip(false);

        card.transform.DOPath(path, 1f, PathType.CatmullRom).SetEase(Ease.Linear).OnComplete(() =>
        {
            card.drag.Drop(holder);
        });
    }
    public virtual void OnEmptyDeck()
    {

    }
}
