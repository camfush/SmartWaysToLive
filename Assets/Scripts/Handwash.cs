using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Handwash : SceneController
{
    public GameObject Righthand;
    public GameObject Foam1;
    public GameObject Foam2;
    public GameObject Foam3;
    private int threshold = 35;

    // Start is called before the first frame update
    void Awake()
    {
        GenericSetup();
    }

    private void Start()
    {
        Foam1.SetActive(false);
        Foam2.SetActive(false);
        Foam3.SetActive(false);
    }

    void FixedUpdate()
    {
        print(Righthand.GetComponent<Handmove>().distance);
        ManageTime();
        if (Righthand.GetComponent<Handmove>().distance > threshold)
        {
            Foam1.SetActive(true);
        }
        if (Righthand.GetComponent<Handmove>().distance > threshold * 2)
        {
            Foam2.SetActive(true);
            Foam1.SetActive(false);
        }
        if (Righthand.GetComponent<Handmove>().distance > threshold * 3)
        {
            Foam3.SetActive(true);
            Foam2.SetActive(false);
        }
        if (Righthand.GetComponent<Handmove>().distance > threshold * 4)
            PlayerSuccess();
    }
}