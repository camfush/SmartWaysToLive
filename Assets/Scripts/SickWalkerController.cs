using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickWalkerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 6 * GameInfo.SpeedMultiplier);
        GetComponent<SpriteRenderer>().color = newColor(UnityEngine.Random.Range(0,8));
    }

    private void Update()
    {
        if (gameObject.transform.position.y > 0)
        {
            Vector3 walkerPosition = gameObject.transform.position;
            walkerPosition.z = 1;
            gameObject.transform.position = walkerPosition;
        }
    }

    private Color newColor(int Number)
    {
       
        switch (Number)
        {
            case 0:
                return Color.blue;
            case 1:
                return Color.cyan;
            case 2:
                return Color.gray;
            case 3:
                return Color.green;
            case 4:
                return Color.grey;
            case 5:
                return Color.magenta;
            case 6:
                return Color.red;
            case 7:
                return Color.white;
            case 8:
                return Color.yellow;
            default:
                return Color.black; 
        }
        
    }
}
