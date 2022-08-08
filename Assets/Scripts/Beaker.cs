using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beaker : MonoBehaviour
{
    private BeakerManager manager;
    [SerializeField] Color[] colors = new Color[4];
    [SerializeField] GameObject contentObj;
    private Color[] orig;
    private int index;
    private float height;
    private Stack<GameObject> contents;
    // Start is called before the first frame update
    void Start()
    {
        orig = colors;
        Color[] fullArr = new Color[4];
        height = contentObj.GetComponent<SpriteRenderer>().size.y;
        contents = new Stack<GameObject>();
        for (index = 0; index < colors.Length; index++)
        {
            GameObject row = Instantiate(contentObj, this.transform.parent);
            row.GetComponent<SpriteRenderer>().color = colors[index];
            row.transform.localPosition = new Vector3(0, index * height * row.transform.localScale.y, 0);
            fullArr[index] = colors[index];
            contents.Push(row);
        }
        manager = this.GetComponentInParent<BeakerManager>();
        colors = fullArr;
    }

    public void OnMouseDown()
    {
        manager.GetComponent<BeakerManager>().process(this);
    }

    public bool moveTo(Beaker beak)
    {
        if (index > 0)
        {
            GameObject row = contents.Peek();
            if (beak.push(row))
            {
                contents.Pop();
                index--;
                return true;
            }
        }
        return false;
    }

    public bool push(GameObject row)
    {
        if (row == null || full()) return false;
        Color col = row.GetComponent<SpriteRenderer>().color;
        if (index > 0 && col != colors[index - 1]) return false;
        row.transform.parent = this.transform.parent;
        row.transform.localPosition = new Vector3(0, index * height * row.transform.localScale.y, 0);
        colors[index] = row.GetComponent<SpriteRenderer>().color;
        contents.Push(row);
        index++;
        return true;
    }

    public bool full() { return index == 4; }
    public bool empty() { return index == 0; }
    public bool pure()
    {
        for (int i = 0; i < index; i++)
            if (colors[i] != colors[0])
                return false;
        return true;
    }

    public void reset()
    {
        while (contents.Count > 0)
            Destroy(contents.Pop());
        colors = orig;
        Start();
    }
}
