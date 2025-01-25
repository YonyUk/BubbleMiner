using System;
using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;
using Variables;

public class FoodCollector : MonoBehaviour, IEqquipable
{
    public string Name => "FoodCollector";

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
            occupied = Math.Min(target.GetComponent<Animals>().Food.Units + occupied, storage);
            target.GetComponent<Animals>().Food = null;
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag(Globals.animalTag)){
            canUse = true;
            target = other.gameObject;   
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag(Globals.animalTag)){
            if(other.GetComponent<Animals>().Food.Units > 0){
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