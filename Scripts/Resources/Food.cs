using Architecture.Resource;
using UnityEngine;

public class Food : MonoBehaviour, IResource
{
	public Architecture.Resource.Resources Type {
		get{ return Architecture.Resource.Resources.Food; }
	}

	public int Units{
		get{ return unit;}
	}

    int unit;
    public Food(int unit){
        this.unit = unit;
    }
}
