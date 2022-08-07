using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    [SerializeField] GameObject beakerManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseEnter()
    {
        this.GetComponent<Interactable>().select();
    }

    public void OnMouseExit()
    {
        this.GetComponent<Interactable>().deselect();
    }

    public void OnMouseDown()
    {
        //beakerManager.GetComponent<BeakerManager>().process();
    }
}
