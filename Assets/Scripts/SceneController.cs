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

    // Start is called before the first frame update
    void Start()
    {
        GameInfo.ResetValues();
        GameObject gameOverlay = Instantiate(GameOverlay);
        for (int i = 0; i < GameInfo.PlayerLives; i++)
        {
            gameOverlay.transform.GetChild(0).GetChild(i).transform.GetComponent<Image>().sprite = AvailableLife;
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
