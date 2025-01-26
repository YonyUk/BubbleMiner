using UnityEngine;
using Architecture.Structures;
using Architecture.Resource;
using Resources = Architecture.Resource.Resources;
using Variables;
public class AlmacenDeBurbujas : MonoBehaviour, IStructure<Oxigen>
{
	public Resources Material { get; private set; }
    int quantity = 0;
    int maxquantity = 20;
    int cont = 0;
    bool CanProduce =true;
    public void AddResource(IResource resource)
    {
        if(Material == resource.Type){
            if(quantity + resource.Units < maxquantity){
                quantity+= resource.Units;
            }
            else quantity = maxquantity;
        }
    }

    public Oxigen Produce()
    {
        int produceOxygen = 0;
        if(CanProduce)
        {
            if(quantity/Globals.BubblesProduceControler != 0)produceOxygen = quantity/Globals.BubblesProduceControler;
            if(produceOxygen != 0)
            {
                quantity%=Globals.BubblesProduceControler;
                CanProduce = false;
            }
        }
        return new Oxigen(produceOxygen);
    }
    void FixedUpdate() {
        cont++;
        if(cont == Globals.RefreshStructureProduce)
        {
            cont = 0;
            CanProduce = true;
        }
    }
}
