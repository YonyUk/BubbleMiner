using UnityEngine;
using Architecture.Resource;
public class Oxigen : MonoBehaviour,IResource
{
    public Architecture.Resource.Resources Type => Architecture.Resource.Resources.Oxygen;

    public int Units => units;
    int units;
    public Oxigen(int units){
        this.units = units;
    }
}