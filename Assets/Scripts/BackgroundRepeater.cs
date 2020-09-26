using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    private Vector2 velocity;
    private float spriteHeight;
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteHeight = spriteRenderer.sprite.bounds.size.y;
        velocity = new Vector2(0, 3 * GameInfo.SpeedMultiplier);
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((transform.position.y - spriteHeight) > cameraTransform.position.y)
        {
            Vector3 newPos = transform.position;
            newPos.y -= 2.0f * spriteHeight;
            transform.position = newPos;
        }
    }
}
