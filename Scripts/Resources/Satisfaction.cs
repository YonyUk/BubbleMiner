using Architecture.Resource;
using UnityEngine;

public class Satisfaction : MonoBehaviour, IResource
{
	public Architecture.Resource.Resources Type{
		get{ return Architecture.Resource.Resources.Satisfaccion; }
	}

	public int Units{
		get { return unit; }
	}
    int unit;
    public Satisfaction(int unit){
        this.unit = unit;
    }
}
