using System.Collections;
using System.Collections.Generic;
using Architecture.Resource;
using UnityEngine;

public class Mineral : MonoBehaviour, IResource
{
    public Architecture.Resource.Resources Type => Architecture.Resource.Resources.Mineral;

    public int Units => units;
    public int units;

    public Mineral(int units)
    {
        this.units = units;
    }
}
