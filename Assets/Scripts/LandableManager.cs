using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandableManager : MonoBehaviour
{
    private Landable[] landables;
    private int landIndex = 0;

    public void Start()
    {
        landables = new Landable[this.transform.childCount];
        for (int i = 0; i < landables.Length; i++)
            landables[i] = this.transform.GetChild(i).GetComponent<Landable>();
    }

    public bool trigger(Landable obj)
    {
        if (landables[landIndex] == obj)
        {
            landIndex++;
            return true;
        }
        else
            while(landIndex > 0)
                landables[--landIndex].reset();
        return false;
    }
}
