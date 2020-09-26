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
    public Sprite Zero;
    public Sprite One;
    public Sprite Two;
    public Sprite Three;
    public Sprite Four;
    public Sprite Five;
    public Sprite Six;
    public Sprite Seven;
    public Sprite Eight;
    public Sprite Nine;

    private GameObject fGameOverlay;

    // Start is called before the first frame update
    void Start()
    {
        GameInfo.TickRate = 1;
        GameInfo.ResetValues();
        fGameOverlay = Instantiate(GameOverlay);
        // Sets image from ConsumedLife to AvailableLife for each life the player still has
        for (int i = 0; i < GameInfo.PlayerLives; i++)
        {
            fGameOverlay.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = AvailableLife;
        }

        GameInfo.PlayerScore = 212;

        int singlesDigit = GameInfo.PlayerScore % 10;
        int tensDigit = (GameInfo.PlayerScore - singlesDigit) % 100 / 10;
        int hundredsDigit = (GameInfo.PlayerScore - singlesDigit - tensDigit) % 1000 / 100;

        fGameOverlay.transform.GetChild(2).GetChild(0).transform.GetComponent<Image>().sprite = GetSpriteForInt(singlesDigit);
        fGameOverlay.transform.GetChild(2).GetChild(1).transform.GetComponent<Image>().sprite = GetSpriteForInt(tensDigit);
        fGameOverlay.transform.GetChild(2).GetChild(2).transform.GetComponent<Image>().sprite = GetSpriteForInt(2);
    }

    void FixedUpdate()
    {
        if (IncTick())
        {
            Vector3 ronaPosition = fGameOverlay.transform.GetChild(1).GetChild(1).localPosition;
            ronaPosition.x -= 1;
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

    private Sprite GetSpriteForInt(int Number)
    {
        switch(Number)
        {
            case 0:
                return Zero;
            case 1:
                return One;
            case 2:
                return Two;
            case 3:
                return Three;
            case 4:
                return Four;
            case 5:
                return Five;
            case 6:
                return Six;
            case 7:
                return Seven;
            case 8:
                return Eight;
            case 9:
                return Nine;
        }
        return Zero;
    }
}
