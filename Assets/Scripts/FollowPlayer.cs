using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private bool connected = true;
    private Vector3 difference;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        reconnect();
    }

    // Update is called once per frame
    void Update()
    {
        if (connected)
        {
            this.transform.position += (player.transform.position - this.transform.position - difference)/50;
        }
        if (Input.GetKeyDown(KeyCode.Space)) disconnect();
        else if (Input.GetKeyUp(KeyCode.Space)) reconnect();
    }

    public void disconnect() { connected = false; }

    public void reconnect()
    {
        connected = true;
        difference = player.transform.position - this.transform.position;
    }
}
