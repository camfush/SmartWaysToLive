using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManSneeze : SceneController
{
    public const double endPoint = -7.2;
    private GameObject egg, mask;
    private Animator anim;
    private void Start()
    {
        egg = GameObject.Find("Sneeze Animation");
        mask = GameObject.Find("EggMask");
        anim = egg.GetComponent<Animator>();
    }

    private void Update()
    {
        if(mask.GetComponent<Transform>().localPosition.x == endPoint)
        {

        }
       
    }

    protected override void TimeUp()
    {
        anim.Play("EggMan Sneeze");

    }

}
