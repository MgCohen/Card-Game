using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
public class CardHighlight : Highlight
{
    public override void Mark(bool status)
    {
        base.Mark(status);
        transform.DOScale(status ? 1.2f : 1f, 0.25f);
        GetComponent<SortingGroup>().sortingOrder = status ? 1 : 0;
    }

}
