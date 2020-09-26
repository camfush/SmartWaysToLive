using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidRoadController : SceneController
{
    public GameObject SickWalker;

    // Start is called before the first frame update
    void Awake()
    {
        GenericSetup();
    }

    void FixedUpdate()
    {
        ManageTime();
        Instantiate(SickWalker, new Vector3 (0, -2, 0), Quaternion.identity);
    }
}
