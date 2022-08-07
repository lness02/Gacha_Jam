using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent uEvent;
    [SerializeField] Sprite outlinedSprite;
    private Sprite defSprite;

    private void Start()
    {
        this.gameObject.layer = 6;
        defSprite = this.GetComponent<SpriteRenderer>().sprite;
        if (outlinedSprite == null)
            outlinedSprite = defSprite;
    }
    public void interact()
    {
        uEvent.Invoke();
    }

    public void select()
    {
        this.GetComponent<SpriteRenderer>().sprite = outlinedSprite;
    }
    public void deselect()
    {
        this.GetComponent<SpriteRenderer>().sprite = defSprite;
    }
}
