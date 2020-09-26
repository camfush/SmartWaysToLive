using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeeLogic : MonoBehaviour
{
    public Vector3 Velocity;
    private Vector3 VelocityChange;
    private bool Dragging;
    private float TicksWithoutChangingDirection = 0;
    private BoxCollider2D Collider;

    // Start is called before the first frame update
    void Start()
    {
        VelocityChange = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1));
        Dragging = false;
        Collider = GetComponent<BoxCollider2D>();
        GetComponent<Animator>().SetFloat("Speed", 1);
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Collider == Physics2D.OverlapPoint(mousePos))
            {
                Dragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Dragging = false;

            GetComponent<Animator>().SetFloat("Speed", 1);
        }

        if (Dragging)
        {
            Vector3 position = this.transform.position;
            position.x = mousePos.x;
            position.y = mousePos.y - 0.4f;
            this.transform.position = position;

            GetComponent<Animator>().SetFloat("Speed", 2);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Dragging)
        {
            //Velocity += VelocityChange;
            Velocity = Vector3.Normalize(Velocity);
            Vector3 position = transform.position;
            position += 0.01f * Velocity * GameInfo.SpeedMultiplier;
            transform.position = position;

            if (Random.Range(0, TicksWithoutChangingDirection) > 50)
            {
                VelocityChange = new Vector3(Random.Range(0, 1f), Random.Range(0, 1f)) * 0.01f;
                TicksWithoutChangingDirection = 0;
            }

            TicksWithoutChangingDirection += GameInfo.SpeedMultiplier;
        }
    }
}
