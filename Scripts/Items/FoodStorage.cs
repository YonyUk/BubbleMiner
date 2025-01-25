using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;
using Variables;

public class FoodCollector : MonoBehaviour, IEqquipable
{
    public string Name => "FoodCollector";

    public int storage {get; private set;}
    int occupied {get; set;}

    public void Upgrade()
    {
        storage += 4;
    }

    public void Use()
    {
        occupied++;
    }

    void Start()
    {
        storage = Globals.foodStorageCapacity;
    }

    void Update()
    {
        
    }
}
