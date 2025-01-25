using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;
using Variables;

public class Harpoon : MonoBehaviour, IEqquipable
{
    public int damage;
    public bool loaded = true;
    public bool pickUp;
    GameObject harpoonBar;

    public string Name => "Harpoon";

    public void Upgrade()
    {
        damage += 4;
    }

    public void Use()
    {
        if(loaded){
        GetComponentInChildren<Rigidbody>().AddForce(transform.forward * 10);
        transform.DetachChildren();
        loaded = false;
        }
        else if(pickUp){
            harpoonBar.transform.SetParent(transform, false);
            loaded = true;
        } 
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag(Globals.harpoonlBarTag))pickUp = true;
    }

    void Start(){
        damage = 15;
        harpoonBar = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        
    }
}
