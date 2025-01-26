using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;
using UnityEngine;
using Variables;

public class Harpoon : MonoBehaviour, IEqquipable
{
    public Transform player;
    public int damage;
    public bool loaded = true;
    public bool pickUp;
    GameObject harpoonBar;
    Rigidbody rb;
    public string Name => "Harpoon";
    public bool flag;
    public void Upgrade()
    {
        damage += 4;
    }

    public void Use()
    {
        if (loaded)
        {
            rb = GetComponentInChildren<Rigidbody>();
            loaded = false;
        }
        else if (pickUp)
        {

            //flag = false;
            //loaded = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Globals.harpoonlBarTag)) pickUp = true;
    }

    void Start()
    {
        damage = 15;
        harpoonBar = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (rb != null && !flag)
        {
            Invoke("shoot", 1.1f);
        }
    }
    void shoot()
    {
        if (rb != null)
        {
            rb.isKinematic = false;
            transform.GetChild(0).SetParent(null);

            rb.AddForce(player.transform.forward * 25, ForceMode.Impulse);
            flag = true;
            rb = null;

        }
    }
}
