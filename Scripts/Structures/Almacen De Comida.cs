using UnityEngine;
using Architecture.Structures;
using Architecture.Resource;
using Variables;
//using Unity.VisualScripting;
public class AlmacenDeComida : MonoBehaviour, IStructure
{
	public Architecture.Resource.Resources Material{
		get { return Architecture.Resource.Resources.Food; }
	}
    int quantity = 0;
    int maxquantity = 20;
    bool CanProduce = true;
    int cont = 0;
    public void AddResource(IResource resource)
    {
        if(Material == resource.Type){
            if(quantity + resource.Units < maxquantity){
                quantity+= resource.Units;
            }
            else quantity = maxquantity;
        }
    }

    public void Produce(System.Action<Architecture.Resource.Resources,int> action)
    {
        int produced = 0;
        if(CanProduce)
        {
            if(quantity/Globals.FoodProduceControler != 0)
                produced = quantity/Globals.FoodProduceControler;
            if(produced != 0) {
                quantity%= Globals.FoodProduceControler;
                CanProduce = false;
            }
        }
		action (Architecture.Resource.Resources.Food,produced);
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
