using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public float speed;
    private float width;

    private void Start()
    {
        // Get the size of the background sprite renderer.
        width = GetComponent<SpriteRenderer>().bounds.size.x;    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -width)
        {
            Vector2 vector = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + vector;
        }
    }
}
