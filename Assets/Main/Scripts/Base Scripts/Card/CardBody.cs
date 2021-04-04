using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardBody : MonoBehaviour
{

    bool flipped = false;
    public GameObject front;
    public GameObject back;


    public virtual void Setup(CardVisuals cardVisual)
    {

    }

    public virtual void Flip(bool status, bool withAnimation = true, float flipTime = 0.5f)
    {
        flipped = status;
        if (!withAnimation)
        {
            front.SetActive(!flipped);
            back.SetActive(flipped);
            return;
        }
        transform.DORotate(new Vector3(0, 90, 0), flipTime/2).SetEase(Ease.Linear).OnComplete(() =>
        {
            front.SetActive(!flipped);
            back.SetActive(flipped);
            transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
            transform.DORotate(new Vector3(0, 0, 0), flipTime/2).SetEase(Ease.Linear);
        });
    }
}


//edit here all your cards needs
[SerializeField]
public class CardVisuals
{
    public string cardtext;
    public string cardname;
    public Sprite cardBg;
    public Sprite cardSprite;
    public Sprite cardBack;
}
