using System;
using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using Unity.VisualScripting;
using UnityEngine;
using Variables;


public class BubbleCollector : MonoBehaviour, IEqquipable
{
    public string Name => "BubbleCollector";
    public int storage { get; private set; }
    public int occupied { get; set; } = 0;
    public bool canUse;
    float secondsToCollect;
    GameObject target;
    float collectDelay = 0f;


    public void Upgrade()
    {
        storage += 4;
        secondsToCollect -= 2;
    }

    public void Use()
    {
        if (canUse)
        {
            if (collectDelay <= secondsToCollect)
            {
                collectDelay += Time.deltaTime;
            }


        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Globals.plantsTag))
        {
            if (other.GetComponent<Plants>().Oxygen != null)
            {
                canUse = true;
                target = other.gameObject;

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Globals.plantsTag))
        {
            canUse = false;
            target = null;

        }
    }
    void OnEnable()
    {
        storage = Globals.bubbleStorageCapacity;
        secondsToCollect = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (target.GetComponent<Plants>().Oxygen != null && collectDelay > 4.5f)
            {
                target.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
                target.gameObject.transform.GetChild(0).GetComponent<OxygenPartManager>().flag = false;
                occupied = Math.Min(target.GetComponent<Plants>().Oxygen.Units + occupied, storage);
                collectDelay = 0;
                target.GetComponent<Plants>().Oxygen = null;

            }

        }

    }
}
