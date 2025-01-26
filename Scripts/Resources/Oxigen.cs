using UnityEngine;
using Architecture.Resource;
public class Oxigen : MonoBehaviour,IResource
{
	public Architecture.Resource.Resources Type {
		get{ return Architecture.Resource.Resources.Oxygen; }
	}

	public int Units{
		get { return units;}
	}
    int units;
    public Oxigen(int units){
        this.units = units;
    }
}