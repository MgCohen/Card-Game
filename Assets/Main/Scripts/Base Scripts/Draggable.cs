using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public bool dragging;

    Vector3 dragOffset;


    public void OnBeginDrag(PointerEventData eventData)
    {
        Pick();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = CardManager.mousePos + dragOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Drop();
    }

    public virtual void Pick()
    {
        var pos = CardManager.mousePos;
        dragOffset = transform.position - pos;
        dragging = true;
    }

    public virtual void Drop()
    {
        dragging = false;
    }

    public void GoTo(Vector3 position, bool animated = true)
    {
        if (dragging) return;
        if (!animated)
        {
            transform.DOKill();
            transform.position = position;
            return;
        }

        transform.DOKill();
        transform.DOMove(position, 35).SetEase(Ease.Linear).SetSpeedBased();
    }
}
