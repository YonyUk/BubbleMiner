using UnityEngine;
using Architecture.Structures;
using Architecture.Resource;
using Variables;
public class AlmacenDeComida : MonoBehaviour, IStructure<Food>
{
    public Architecture.Resource.Resources Material => Architecture.Resource.Resources.Food;
    int quantity = 0;

    public void AddResource(IResource resource)
    {
        if(Material == resource.Type)quantity+= resource.Units;
    }

    public Food Produce()
    {
        int produced = 0;
        if(quantity/Globals.FoodProduceControler != 0)produced = quantity/Globals.FoodProduceControler;
        if(produced != 0) quantity%= Globals.FoodProduceControler;
        return new Food(produced);
    }
}
