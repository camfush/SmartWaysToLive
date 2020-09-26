using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : SceneController
{
    
    public GameObject mask;
    public GameObject green;
    public GameObject blue;
    public GameObject red;

    private bool caughtRed, caughtGreen, caughtBlue;
    private void Start()
    {
 
        caughtRed = false;
        caughtBlue = false;
        caughtGreen = false;

        green.transform.position = new Vector3(8.9f, Random.Range(-4.0f, 4.0f), 0);
        red.transform.position = new Vector3(15.27f, Random.Range(-4.0f, 4.0f), 0);
        blue.transform.position = new Vector3(11.87f, Random.Range(-4.0f, 4.0f), 0);
    }


    private void FixedUpdate()
    {
        ManageTime();

        green.transform.Translate(-.03f * GameInfo.SpeedMultiplier, 0, 0);
        red.transform.Translate(-.107f * GameInfo.SpeedMultiplier, 0, 0);
        blue.transform.Translate(-.048f * GameInfo.SpeedMultiplier, 0, 0);

        if (CheckCollision(green, mask))
        {
            green.SetActive(false);
            caughtGreen = true;
        }
        if (CheckCollision(red, mask))
        {
            red.SetActive(false);
            caughtRed = true;
        }
        if (CheckCollision(blue, mask))
        {
            blue.SetActive(false);
            caughtBlue = true;
        }



        if (caughtBlue && caughtGreen && caughtRed)
        {
            PlayerSuccess();
        }
    }

    private bool CheckCollision(GameObject rona, GameObject mask)
    {
        if (rona.transform.position.x <= mask.transform.position.x + 1.1f && rona.transform.position.x >= mask.transform.position.x +1f - 0.1f)
        {
            if (rona.transform.position.y >= mask.transform.position.y - 1.065f && rona.transform.position.y <= mask.transform.position.y + 1.065f) {
                return true;
            }
        }
        return false;
    }

}



