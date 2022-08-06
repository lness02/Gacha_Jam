using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    // Start is called before the first frame update
    public static float PLAYER_HEALTH = 10f;
    [SerializeField] GameObject heart;
    private GameObject[] hearts;
    void Start()
    {
        initHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void initHealth()
    {
        hearts = new GameObject[(int)Mathf.Ceil(PLAYER_HEALTH)];
        Vector2 size = heart.GetComponent<Renderer>().bounds.size;
        Vector2 max = Camera.main.WorldToViewportPoint(Vector2.one) - new Vector3(0.5f, 0.5f, 0);
        max = new Vector2(-0.5f / max.x, 0.5f / max.y);

        for (int i = 0; i < hearts.Length; i++)
        {
            GameObject currHeart = Instantiate(heart, Camera.main.transform);
            currHeart.transform.position = max + new Vector2(i * size.x * 1.1f, 0);
        }
    }
}
