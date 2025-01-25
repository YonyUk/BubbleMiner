using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;

public class Harpoon : MonoBehaviour, IEqquipable
{
    public int damage;

    public string Name => "Harpoon";

    public void Upgrade()
    {
        damage += 4;
    }

    public void Use()
    {
        GetComponentInChildren<Rigidbody>().AddForce(transform.forward * 10);
    }

    void Start(){
        damage = 15;
    }
    void Update()
    {
        
    }
}
