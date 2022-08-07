using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent uEvent;
    [SerializeField] Color recolor;
    private Color defColor;

    private void Start()
    {
        this.gameObject.layer = 6;
        defColor = this.GetComponent<SpriteRenderer>().color;
        if (recolor == Color.clear)
            recolor = defColor;
    }
    public void interact()
    {
        uEvent.Invoke();
    }

    public void select()
    {
        this.GetComponent<SpriteRenderer>().color = recolor;
    }
    public void deselect()
    {
        this.GetComponent<SpriteRenderer>().color = defColor;
    }
}
