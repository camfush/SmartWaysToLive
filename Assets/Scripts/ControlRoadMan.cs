using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoadMan : MonoBehaviour
{
    private BoxCollider2D collider;
    private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        canMove = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            position.x = Mathf.Sign(mousePos.x) * Mathf.Min(Mathf.Abs(mousePos.x), 3);
            this.transform.position = position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }
    }
}
