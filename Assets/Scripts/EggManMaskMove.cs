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
    Vector3 clickedPos;
    Vector3 offSet;
    Vector3 mousepos;
    float xpos, ypos;
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
            clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offSet = transform.position - clickedPos;
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
            }
        }
        if (canMove)
        {
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            xpos = Mathf.Max((float)EggManSneeze.endPoint, mousepos.x);
            transform.position = new Vector3(xpos, transform.localPosition.y, 0);
        }
        distance += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
    }
}
