using Architecture.Resource;
using Architecture.Structures;
using UnityEngine;
using Variables;

public class Condominio : MonoBehaviour, IStructure<People>
{
    public Architecture.Resource.Resources Material =>Architecture.Resource.Resources.People;
    int quantity =0;
    bool CanProduce = true;
    int cont = 0;
    public void AddResource(IResource resource)
    {
        if(Material == resource.Type){
            quantity += resource.Units;
        }
    }

    public People Produce()
    {
        int produced = 0;
        if(CanProduce)
        {
            if(quantity/Globals.PeopleProduceControle != 0)
                produced = quantity/Globals.PeopleProduceControle;
            if(produced != 0)
            { 
                quantity%= Globals.PeopleProduceControle;
                CanProduce = false;
            }

        }
        return new People(produced);
    }
    void FixedUpdate()
    {
        cont++;
        if(cont == Globals.RefreshStructureProduce){
            cont = 0;
            CanProduce = true;
        }
    }
}
