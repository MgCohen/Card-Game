using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cartas = new List<GameObject>();
    public Transform hand;

    private void OnEnable()
    {
        Battle.deck = this;
    }



    public void Draw()
    {
        if (cartas.Count <= 0) return;
        Instantiate(cartas[0], hand);
        cartas.RemoveAt(0);
    }
}
