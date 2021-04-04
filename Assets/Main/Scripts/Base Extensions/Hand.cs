using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;
public class Hand : CardField
{

    bool picking = false;

    [FoldoutGroup("Waypoints")]
    public Transform startPoint, centerPoint, endPoint;

    public override void OnPickCard(Card card)
    {
        base.OnPickCard(card);
        picking = true;
    }
    public override void OnDropCard(Card card)
    {
        base.OnDropCard(card);
        picking = false;
    }
    private void Update()
    {
        if (picking)
            UpdateCards();
    }

    public override void UpdateCards()
    {
        currentCards = currentCards.OrderBy(x => x.transform.position.x).ToList();
        int amount = currentCards.Count;
        float spacing = 1f / amount;
        for (int i = 0; i < amount; i++)
        {
            var pos = QuadraticCurve((spacing / 2) + spacing * i);
            currentCards[i].GetComponent<CardDrag>().GoTo(pos);
        }
    }

    public Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }
    public Vector3 QuadraticCurve(float t)
    {
        Vector3 p0 = Lerp(startPoint.position, centerPoint.position, t);
        Vector3 p1 = Lerp(centerPoint.position, endPoint.position, t);
        return Lerp(p0, p1, t);
    }

    public override bool isAvailable()
    {
        return true;
    }
}

