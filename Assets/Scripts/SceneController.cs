using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GameInfo;

// Parent class for all scene controllers.
public class SceneController : MonoBehaviour
{
    public GameObject GameOverlay;
    public Sprite AvailableLife;
    public Sprite ConsumedLife;

    private GameObject fGameOverlay;

    // Start is called before the first frame update
    void Start()
    {
        GameInfo.TickRate = 10;
        GameInfo.ResetValues();
        fGameOverlay = Instantiate(GameOverlay);
        for (int i = 0; i < GameInfo.PlayerLives; i++)
        {
            fGameOverlay.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = AvailableLife;
        }
    }

    void FixedUpdate()
    {
        if (IncTick())
        {
            Vector3 ronaPosition = fGameOverlay.transform.GetChild(1).GetChild(1).localPosition;
            ronaPosition.x -= 1;
            print(ronaPosition);
            fGameOverlay.transform.GetChild(1).GetChild(1).localPosition = ronaPosition;
        }
    }

    protected void PlayerSuccess()
    {
        GameInfo.IncScore();
    }

    protected void PlayerFailure()
    {

    }
}
