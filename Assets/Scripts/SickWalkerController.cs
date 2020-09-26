using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickWalkerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 2 * GameInfo.SpeedMultiplier);
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
}
