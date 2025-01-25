using Architecture.Resource;
using UnityEngine;

public class People : MonoBehaviour, IResource
{
    public Architecture.Resource.Resources Type => Architecture.Resource.Resources.People;

    public int Units => unit;
    int unit;
    public People(int unit){
        this.unit = unit;
    }
}
