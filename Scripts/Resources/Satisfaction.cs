using Architecture.Resource;
using UnityEngine;

public class Satisfaction : MonoBehaviour, IResource
{
    public Architecture.Resource.Resources Type => Architecture.Resource.Resources.Satisfaccion;

    public int Units => unit;
    int unit;
    public Satisfaction(int unit){
        this.unit = unit;
    }
}
