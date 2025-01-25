using Architecture.Resource;
using UnityEngine;

public class Food : MonoBehaviour, IResource
{
    public Architecture.Resource.Resources Type => Architecture.Resource.Resources.Food;

    public int Units => unit;

    int unit;
    public Food(int unit){
        this.unit = unit;
    }
}
