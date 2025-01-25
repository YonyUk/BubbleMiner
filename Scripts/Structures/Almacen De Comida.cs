using UnityEngine;
using Architecture.Structures;
using Architecture.Resource;
using Variables;
using Unity.VisualScripting;
public class AlmacenDeComida : MonoBehaviour, IStructure<Food>
{
    public Architecture.Resource.Resources Material => Architecture.Resource.Resources.Food;
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

    public Food Produce()
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
        return new Food(produced);
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
