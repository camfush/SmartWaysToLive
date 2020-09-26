using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EggManMaskMove : MonoBehaviour
{
    private BoxCollider2D collider;
    private bool canMove;
    public float distance;
    private Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        canMove = false;
        distance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lastPosition = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
            }
        }
        if (canMove)
        {
            Vector3 position = this.transform.position;
            position.x = mousePos.x;
            this.transform.position = position;
        }
        distance += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
    }
}
