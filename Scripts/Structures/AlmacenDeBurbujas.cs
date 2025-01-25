using UnityEngine;
using Architecture.Structures;
using Architecture.Resource;
using Resources = Architecture.Resource.Resources;
using Variables;
public class AlmacenDeBurbujas : MonoBehaviour, IStructure<Oxigen>
{
    public Resources Material {get;}
    int quantity = 0;
    public void AddResource(IResource resource)
    {
        if(resource.Type == Material){
            quantity += resource.Units;
        }
    }

    public Oxigen Produce()
    {
        int produceOxygen = 0;
        if(quantity/Globals.BubblesProduceControler != 0)produceOxygen = quantity/Globals.BubblesProduceControler;
        if(produceOxygen != 0)quantity%=Globals.BubblesProduceControler;
        return new Oxigen(produceOxygen);
    }
}
