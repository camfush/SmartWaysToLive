


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class pongController : SceneController
{
    public GameObject mask;
    public GameObject green;
    public GameObject blue;
    public GameObject red;

    // Start is called before the first frame update
    void Awake()
    {
        GenericSetup();
    }

    private void Start()
    {
        green.transform.position = new Vector3(8.9f, Random.Range(-4.0f, 2.0f), 0);
        red.transform.position = new Vector3(15.27f, Random.Range(-4.0f, 2.0f), 0);
        blue.transform.position = new Vector3(11.87f, Random.Range(-4.0f, 2.0f), 0);

    }

    void FixedUpdate()
    {
        green.transform.Translate(-.02f, 0, 0);
        red.transform.Translate(-.017f, 0, 0);
        blue.transform.Translate(-.024f, 0, 0);

    }
}