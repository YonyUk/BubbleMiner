using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
public class capsuleController : MonoBehaviour
{
    public static capsuleController capsula;
    public Movement player;
    public bool playerIn = true;
    public City city;
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
        if (other.tag == Globals.playerTag)
        {
            playerIn = true;
            print("enter");
            city.ManageStorage(player.oxygenStorage, player.foodStorage);
            player.oxygenStorage = 0;
            player.foodStorage = 0;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == Globals.playerTag)
        {
            print("out");

            playerIn = false;

        }
    }
}
