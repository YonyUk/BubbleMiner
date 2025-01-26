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
    int collectPerSeconds = 1;
    GameObject target;
    float collectDelay = 0f;


    public void Upgrade()
    {
        storage += 4;
        collectPerSeconds++;
    }

    public void Use()
    {
        if (canUse)
        {
            collectDelay += Time.deltaTime;
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
    void Start()
    {
        storage = Globals.bubbleStorageCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (target.GetComponent<Plants>().Oxygen != null && collectDelay > 1.5f && collectDelay > 0)
            {
                collectDelay = 0;
                target.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
                target.gameObject.transform.GetChild(0).GetComponent<OxygenPartManager>().flag = false;

                Debug.Log("te amo idania");
                if (occupied < storage)
                {
                    occupied += collectPerSeconds;
                    if (target.GetComponent<Plants>().Oxygen.Units > 0) target.GetComponent<Plants>().Oxygen = new Oxigen(target.GetComponent<Plants>().Oxygen.Units - 1);
                    else target.GetComponent<Plants>().Oxygen = null;
                }



            }

        }

        else collectDelay = 0;
    }
}
