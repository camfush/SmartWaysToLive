using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidRoadController : SceneController
{
    public GameObject SickWalker;
    private float TicksSinceLastWalker;

    // Start is called before the first frame update
    void Awake()
    {
        GenericSetup();
        TicksSinceLastWalker = 50;
    }

    void FixedUpdate()
    {
        ManageTime();
        if (Random.Range(0, TicksSinceLastWalker) > 150)
        {
            Instantiate(SickWalker, new Vector3(Random.Range(-3, 3), -7, 0), Quaternion.identity);
            TicksSinceLastWalker = 0;
        }
        TicksSinceLastWalker += GameInfo.SpeedMultiplier;
    }
}
