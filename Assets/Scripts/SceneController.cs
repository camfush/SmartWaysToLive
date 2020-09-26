using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInfo;

// Parent class for all scene controllers.
public class SceneController : MonoBehaviour
{
    public GameObject GameOverlay;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(GameOverlay);
    }

    protected void PlayerSuccess()
    {
        GameInfo.IncScore();
    }

    protected void PlayerFailure()
    {

    }
}
