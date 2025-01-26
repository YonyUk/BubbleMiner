using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;
using Variables;
public class Drill : MonoBehaviour, IEqquipable
{
    public string Name => "Drill";
    public int storage { get; private set; }
    public int occupied { get; set; } = 0;
    public bool canUse;
    int collectPerSeconds = 1;
    GameObject target;
    float collectDelay = 0f;

    public GameObject part;
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
        else
        {
            part.SetActive(false);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Globals.mineTag))
        {
            if (other.GetComponent<Mine>().Mineral != null)
            {
                canUse = true;
                target = other.gameObject;

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Globals.mineTag))
        {
            canUse = false;
            target = null;
            part.SetActive(false);

        }
    }
    void Start()
    {
        storage = Globals.drillStorageCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (target.GetComponent<Mine>().Mineral != null && collectDelay > 1.5f && collectDelay > 0)
            {
                collectDelay = 0;

                if (occupied < storage)
                {
                    occupied += collectPerSeconds;
                    if (target.GetComponent<Mine>().Mineral.Units > 0)
                        target.GetComponent<Mine>().Mineral = new Mineral(target.GetComponent<Mine>().Mineral.Units - 1);
                    else target.GetComponent<Mine>().Mineral = null;
                    part.SetActive(true);
                }



            }

        }

        else collectDelay = 0;
    }


}