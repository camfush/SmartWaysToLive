using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    private BoxCollider2D Collider;
    private bool ButtonClicked;

    // Start is called before the first frame update
    void Start()
    {
        Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Collider == Physics2D.OverlapPoint(mousePos))
            {
                ButtonClicked = true;
                //GetComponent<SpriteRenderer>().color = new Color(100, 100, 100, 255);
                GetComponent<SpriteRenderer>().color = new Color(0, 100, 0, 255);
                Vector3 buttonPos = transform.position;
                buttonPos += new Vector3(0.1f, -0.1f);
                transform.position = buttonPos;
            }
        }

        if (Input.GetMouseButtonUp(0) & ButtonClicked)
        {
            if (Collider == Physics2D.OverlapPoint(mousePos))
            {
                ButtonClicked = true;
                SceneManager.LoadScene(LoadGameManager.GetAvailableGame());
            }
            else
            {
                ButtonClicked = false;
                GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                Vector3 buttonPos = transform.position;
                buttonPos -= new Vector3(0.1f, -0.1f);
                transform.position = buttonPos;
            }
        }
            
    }
}
