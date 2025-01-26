using Architecture.Resource;
using UnityEngine;

public class People : MonoBehaviour, IResource
{
	public Architecture.Resource.Resources Type{
		get { return Architecture.Resource.Resources.People; }
	}

	public int Units{
		get{ return unit; }
	}
    int unit;
    public People(int unit){
        this.unit = unit;
    }
}
