using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggManSneeze : SceneController
{
    public const double endPoint = -7.2;
    public Sprite spriteSuccess;
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

        if(mask.GetComponent<Transform>().localPosition.x <= endPoint+0.5)
        {
            mask.GetComponent<Transform>().localPosition = egg.GetComponent<Transform>().localPosition;
            mask.GetComponent<SpriteRenderer>().sprite = spriteSuccess;
            egg.SetActive(false);
            StartCoroutine(waiterYes());
            

        }
       
    }

    protected override void TimeUp()
    {
        anim.Play("EggMan Sneeze");
        StartCoroutine(waiter());
        
    }

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(1);
        base.TimeUp();
    }
    IEnumerator waiterYes()
    {
        yield return new WaitForSeconds(1);
        PlayerSuccess();
    }

}
