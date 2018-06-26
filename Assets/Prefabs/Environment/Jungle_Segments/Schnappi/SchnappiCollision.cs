using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchnappiCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Coconut")
        {
            transform.parent.GetComponent<Schnappi>().Flee();
        }

        if (other.name == "Player")
        {
            transform.parent.GetComponent<Schnappi>().Attack();
        }
    }
}
