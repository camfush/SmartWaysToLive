using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EscapeeController : SceneController
{
    public GameObject HouseSprite;
    public GameObject HealthySprite;
    public GameObject SickSprite;

    private void Start()
    {
        CreateHouse(1);
        CreateHouse(-1);
    }

    private void CreateHouse(int Multiplier)
    {
        Vector3 location = new Vector3(Random.Range(Multiplier * 2, Multiplier * 4), Random.Range(Multiplier * 2, Multiplier * 2.5f), -1);
        GameObject house = Instantiate(HouseSprite, location, Quaternion.identity);
        house.GetComponent<HouseLogic>().HealthyEscapee = HealthySprite;
        house.GetComponent<HouseLogic>().SickEscapee = SickSprite;

        UnityEvent failureEvent = new UnityEngine.Events.UnityEvent();
        failureEvent.AddListener(PlayerFailure);
        house.GetComponent<HouseLogic>().GameEndEvent = failureEvent;

        UnityEvent successEvent = new UnityEngine.Events.UnityEvent();
        successEvent.AddListener(PlayerSuccess);
        house.GetComponent<HouseLogic>().GameWinEvent = successEvent;
    }

}
