using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HouseLogic : MonoBehaviour
{
    public GameObject HealthyEscapee;
    public GameObject SickEscapee;
    private static int QuarantinedPeople;
    public UnityEvent GameEndEvent;
    public UnityEvent GameWinEvent;

    // Start is called before the first frame update
    void Start()
    {
        CreateEscapee(HealthyEscapee);
        CreateEscapee(SickEscapee);
        CreateEscapee(SickEscapee);
        QuarantinedPeople = 0;
    }

    private void CreateEscapee(GameObject Prefab)
    {
        Vector3 direction = new Vector3(Mathf.Sign(Random.Range(-1, 1)), Mathf.Sign(Random.Range(-1, 1))) * 1.2f +
            new Vector3(Random.Range(0, 0.1f), Random.Range(0, 0.1f)) * 0.1f;
        print(direction);
        GameObject healthyEscapee = Instantiate(Prefab, transform.position + direction, Quaternion.identity);
        healthyEscapee.GetComponent<EscapeeLogic>().Velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Healthy")
        {
            GameEndEvent.Invoke();
        }
        else
        {
            QuarantinedPeople++;
            if (QuarantinedPeople >= 4)
            {
                GameWinEvent.Invoke();
            }
        }

        Destroy(other.gameObject);
    }
}
