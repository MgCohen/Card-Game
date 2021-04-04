using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Highlighter : MonoBehaviour
{
    private void OnEnable()
    {
        CardManager.OnPickCard.AddListener(MarkUp);
        CardManager.OnDropCard.AddListener(Unmark);
    }

    private void OnDisable()
    {
        CardManager.OnPickCard.RemoveListener(MarkUp);
        CardManager.OnDropCard.RemoveListener(Unmark);
    }


    public virtual void MarkUp(Card card)
    {
        card.GetComponent<Highlight>()?.Mark(true);
        foreach(var field in CardManager.instance.GetTargetFields(card))
        {
            field.GetComponent<Highlight>()?.Mark(true);
        }
    }

    public virtual void Unmark(Card card)
    {
        card.GetComponent<Highlight>()?.Mark(false);
        foreach (var field in CardManager.instance.GetTargetFields(card))
        {
            field.GetComponent<Highlight>()?.Mark(false);
        }
    }

}
