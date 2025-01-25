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
    public int storage {get; private set;}
    int occupied {get; set;} = 0;
    bool canUse;
    float secondsToCollect;
    GameObject target;
    
 
    public void Upgrade()
    {
        storage += 4;
        secondsToCollect -= 2;
    }

    public void Use()
    {
        if(canUse){
            float collectDelay = 0f;
            while(collectDelay <= secondsToCollect){
                collectDelay += Time.deltaTime;
            }
            occupied = Math.Min(target.GetComponent<Plants>().Oxygen.Units + occupied, storage);
            target.GetComponent<Plants>().Oxygen = null;
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag(Globals.plantsTag)){
            canUse = true;
            target = other.gameObject;   
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag(Globals.plantsTag)){
            if(other.GetComponent<Plants>().Oxygen.Units > 0){
                canUse = false;
                target = null;
            }
        }
    }
    void Start()
    {
        storage = Globals.bubbleStorageCapacity;
        secondsToCollect = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
