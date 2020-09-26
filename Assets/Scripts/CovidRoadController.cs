using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CovidRoadController : SceneController
{
    public GameObject RoadMan;
    public GameObject SickWalker;
    private float TicksSinceLastWalker;

    // Start is called before the first frame update
    void Awake()
    {
        GenericSetup();
        TicksSinceLastWalker = 10;
    }

    private void Start()
    {
        GameObject roadMan = Instantiate(RoadMan, new Vector3(0, 0, 0), Quaternion.identity);

        UnityEvent roadManEvent = new UnityEngine.Events.UnityEvent();
        roadManEvent.AddListener(PlayerFailure);
        roadMan.GetComponent<ControlRoadMan>().GameEndEvent = roadManEvent;
    }

    protected override void TimeUp()
    {
        PlayerSuccess();
    }

    void FixedUpdate()
    {
        ManageTime();
        if (Random.Range(0, TicksSinceLastWalker) > 50)
        {
            float xPos = Mathf.Sign(Random.Range(-1, 1)) * Random.Range(1.25f, 3);
            Instantiate(SickWalker, new Vector3(xPos, -7, 0), Quaternion.identity);
            TicksSinceLastWalker = 0;
        }
        TicksSinceLastWalker += GameInfo.SpeedMultiplier;
    }
}
