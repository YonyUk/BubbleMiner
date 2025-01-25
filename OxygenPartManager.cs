using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPartManager : MonoBehaviour
{
    public Plants plant;
    public ParticleSystem bubbles;
    public bool flag;

    void Update()
    {
        if (!flag && plant.Oxygen != null)
        {
            bubbles.Play();
            flag = true;
        }
    }
}
