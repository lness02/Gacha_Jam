using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerManager : MonoBehaviour
{
    public GameObject[] beakers;
    private Beaker selected;
    [SerializeField] GameObject[] doors;

    public void Start()
    {
        beakers = new GameObject[this.transform.childCount];
        for (int i = 0; i < beakers.Length; i++)
            beakers[i] = this.transform.GetChild(i).gameObject;
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

    public void OnMouseDown()
    {
        bool cleared = true;
        foreach (GameObject beak in beakers)
        {
            Debug.Log(beak);
            cleared = cleared && beak.GetComponent<Beaker>().pure();
        }
        if(!cleared)
            foreach (GameObject beak in beakers)
                beak.GetComponent<Beaker>().reset();
        //else //meh
            foreach (GameObject door in doors)
                Destroy(door);
    }
}
