using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
public class Damage : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == Globals.playerTag)
        {
            other.GetComponent<Movement>().oxigen -= 0.1f;
        }
    }
}
