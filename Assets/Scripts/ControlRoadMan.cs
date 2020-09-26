using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlRoadMan : MonoBehaviour
{
    private BoxCollider2D Collider;
    private bool CanMove;
    public UnityEvent GameEndEvent;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
        CanMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Collider == Physics2D.OverlapPoint(mousePos))
            {
                CanMove = true;
            }
        }
        if (CanMove)
        {
            Vector3 position = this.transform.position;
            position.x = Mathf.Sign(mousePos.x) * Mathf.Min(Mathf.Abs(mousePos.x), 3);
            this.transform.position = position;
        }
        if (Input.GetMouseButtonUp(0))
        {
            CanMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEndEvent.Invoke();
    }
}
