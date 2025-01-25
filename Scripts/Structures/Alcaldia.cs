using UnityEngine;
using Architecture.Structures;
using Architecture.Resource;
using Resources = Architecture.Resource.Resources;
using System;
using Variables;

public class Alcaldia : MonoBehaviour, IStructure<Satisfaction>
{
    public Resources Material =>GetResources();
    Resources[] materials;
    int [] quantity;
    int maxquantity = 20;
    bool CanProduce= true;
    int cont = 0;
    public void AddResource(IResource resource)
    {
        for(int i = 0; i < materials.Length;i++){
            if(materials[i] == resource.Type){
                if(quantity[i] + resource.Units < maxquantity)
                    quantity[i] += resource.Units;  
                else quantity[i] = maxquantity;                
            }
        }
    }

    public Satisfaction Produce()
    {
        int formulaSatisfaccion = 0;
        if(CanProduce){
            formulaSatisfaccion = Math.Min(quantity[0],quantity[1])/quantity[2];
            quantity[0] -= formulaSatisfaccion*quantity[2];
            quantity[1] -= formulaSatisfaccion*quantity[2];
            CanProduce = false;
        }
        return new Satisfaction(formulaSatisfaccion);
    }
    private Resources GetResources(){
        int iter =-1;
        int n = 100000000;
        for(int i = 0; i < quantity.Length;i++){
            if(quantity[i] < n){
                n = quantity[i];
                iter = i;
            }
        }
        return materials[iter];
    }
    void Start()
    {
        materials = new[] {Resources.Oxygen , Resources.Food, Resources.People};
        quantity = new[] {0,0,0};
    }
    void FixedUpdate()
    {
        cont++;
        if(cont == Globals.RefreshStructureProduce){
            cont = 0;
            CanProduce =true;
        }

    }
}
