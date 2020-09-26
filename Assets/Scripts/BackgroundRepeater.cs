using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    public Vector2 velocity = new Vector2(0, 0);
    private float spriteHeight;
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteHeight = spriteRenderer.sprite.bounds.size.y;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.y + spriteHeight) < cameraTransform.position.y)
        {
            Vector3 newPos = transform.position;
            newPos.y += 2.0f * spriteHeight;
            transform.position = newPos;
        }
    }
}
