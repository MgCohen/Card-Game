using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Previewer : MonoBehaviour
{

    public static Previewer instance;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public Transform previewHolder;
    GameObject currentPreview;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var cards = Physics2D.RaycastAll(CardManager.mousePos, Vector3.forward);
            var card = cards.First(x => x.transform.GetComponent<Card>()).transform.GetComponent<Card>();
            Preview(card);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ClosePreview();
        }
    }


    public virtual void Preview(Card card)
    {
        var copy = Instantiate(card);
        copy.transform.position = previewHolder.transform.position;
        copy.transform.localScale = previewHolder.localScale;
        currentPreview = copy.gameObject;
    }

    public virtual void ClosePreview()
    {
        if (!currentPreview) return;
        Destroy(currentPreview);
        currentPreview = null;
    }
}
