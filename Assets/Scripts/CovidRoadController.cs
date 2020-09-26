using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidRoadController : SceneController
{
    // Start is called before the first frame update
    void Start()
    {
        GenericSetup();
    }

    void FixedUpdate()
    {
        ManageTime();
    }
}
