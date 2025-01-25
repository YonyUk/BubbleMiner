using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;
using Variables;


public class BubbleCollector : MonoBehaviour, IEqquipable
{
    public string Name => "BubbleCollector";
    public int storage {get; private set;}
    int occupied {get; set;} = 0;
    
 
    public void Upgrade()
    {
        storage += 4;
    }

    public void Use()
    {
        occupied ++;
    }

    void Start()
    {
        storage = Globals.bubbleStorageCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
