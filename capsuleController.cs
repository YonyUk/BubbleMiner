using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsuleController : MonoBehaviour
{
    public static capsuleController capsula;
    public bool playerIn = true;

    void Awake()
    {
        if (capsula)
        {
            Destroy(this.gameObject);
        }
        else
        {
            capsula = this;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIn = false;
        }
    }
}
