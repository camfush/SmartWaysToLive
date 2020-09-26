using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
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
    private RectTransform earth, rona;
    private Image single, tens, hundreds;

    // Start is called before the first frame update
    private void Awake()
    {
        GenericSetup();
    }

    void FixedUpdate()
    {
        ManageTime();
    }

    protected void PlayerSuccess()
    {
        GameInfo.IncScore();
    }

    protected void PlayerFailure()
    {
        UnityEngine.Debug.Log("You lose");
    }

    protected void GenericSetup()
    {
        GameInfo.TickRate = 10;
        GameInfo.ResetValues();
        fGameOverlay = Instantiate(GameOverlay);
        // Sets image from ConsumedLife to AvailableLife for each life the player still has
        for (int i = 0; i < GameInfo.PlayerLives; i++)
        {
            fGameOverlay.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = AvailableLife;
        }

        int singlesDigit = GameInfo.PlayerScore % 10;
        int tensDigit = (GameInfo.PlayerScore - singlesDigit) % 100 / 10;
        int hundredsDigit = (GameInfo.PlayerScore - singlesDigit - tensDigit) % 1000 / 100;
        
        // rect transform objects 
        earth = fGameOverlay.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
        rona = fGameOverlay.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();

        // images
        single = fGameOverlay.transform.GetChild(2).GetChild(0).GetComponent<Image>();
        tens = fGameOverlay.transform.GetChild(2).GetChild(1).GetComponent<Image>();
        hundreds = fGameOverlay.transform.GetChild(2).GetChild(2).GetComponent<Image>();

        // add sprites
        single.sprite = GetSpriteForInt(singlesDigit);
        tens.sprite = GetSpriteForInt(tensDigit);
        hundreds.sprite = GetSpriteForInt(hundredsDigit);
    }

    protected void ManageTime()
    {

        Vector3 ronaPosition = rona.localPosition;
        ronaPosition.x -= 5/TickRate;
        rona.localPosition = ronaPosition;

        // Check for running out of time failure
        if (earth.localPosition.x + earth.sizeDelta[0] == rona.localPosition.x - rona.sizeDelta[0])
        {
            PlayerFailure();
        }
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
