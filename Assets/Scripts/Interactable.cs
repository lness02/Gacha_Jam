using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent uEvent;

    private void Start()
    {
        this.gameObject.layer = 6;
    }
    public void interact()
    {
        uEvent.Invoke();
    }
}
