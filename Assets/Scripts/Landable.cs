using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite defaultSprite;
    [SerializeField] Sprite triggerSprite;
    private LandableManager manager;
    private bool triggered = false;

    public void Start()
    {
        //Landable must be a child of a landable manager
        manager = this.GetComponentInParent<LandableManager>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!triggered && collision.gameObject.tag == "Player")
            if (collision.gameObject.transform.position.y > this.transform.position.y)
                if (manager.trigger(this))
                {
                    this.GetComponent<SpriteRenderer>().sprite = triggerSprite;
                    triggered = true;
                }
    }

    public void reset()
    {
        this.GetComponent<SpriteRenderer>().sprite = defaultSprite;
        triggered = false;
    }
}
