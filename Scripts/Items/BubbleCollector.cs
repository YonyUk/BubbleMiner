using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, IEqquipable
{
    public string Name => "BubbleCollector";
    public int secondsToCollect;
    GameObject backpack;

    public void Upgrade()
    {
        secondsToCollect -= 2;
    }

    public void Use()
    {
        
    }

    void Start()
    {
        secondsToCollect = 8;
        //backpack = this.GetComponentInParent<
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
