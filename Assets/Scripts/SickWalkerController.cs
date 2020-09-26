using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickWalkerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 20 / GameInfo.TickRate);
    }
}
