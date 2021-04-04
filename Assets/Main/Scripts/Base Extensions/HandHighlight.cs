using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHighlight : Highlight
{

    public GameObject highlight;
    public override void Mark(bool status)
    {
        base.Mark(status);
        highlight.SetActive(status);
    }
}
