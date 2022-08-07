using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerManager : MonoBehaviour
{
    private Beaker[] beakers;
    private Beaker selected;

    public void Start()
    {
        beakers = new Beaker[this.transform.childCount];
        for (int i = 0; i < beakers.Length; i++)
            beakers[i] = this.transform.GetChild(i).GetComponent<Beaker>();
    }

    public void process(Beaker beak)
    {
        if (selected == null)
        {
            selected = beak;
            selected.GetComponent<Interactable>().select();
        }
        else
        {
            if(selected != beak)
                selected.moveTo(beak);
            selected.GetComponent<Interactable>().deselect();
            selected = null;
        }
    }
}
