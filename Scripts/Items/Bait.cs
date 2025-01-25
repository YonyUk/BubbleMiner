using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;

public class Bait : MonoBehaviour, IEqquipable
{
    public string Name => "Bait";

    public void Upgrade()
    {

    }

    public void Use()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
