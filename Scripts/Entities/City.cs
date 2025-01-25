using System.Collections.Generic;
using Architecture.Resource;
using Architecture.Structures;
using UnityEngine;

public class City : MonoBehaviour
{
    public List<GameObject> StructPrefabs;
    public IStructure<Satisfaction> Alcaldia;
    public IStructure<Oxigen>Bubble;
    public IStructure<Food> Food;
    public IStructure<People> Condo;
    public List<IStructure<IResource>> structures;
    Dictionary<IResource,int>materials;
    void Start()
    {
        StructPrefabs = new List<GameObject>();
        materials = new Dictionary<IResource, int>();
        structures = new List<IStructure<IResource>>();
        structures.Add((IStructure<IResource>)Alcaldia);
        structures.Add((IStructure<IResource>)Bubble);
        structures.Add((IStructure<IResource>)Food);
        structures.Add((IStructure<IResource>)Condo);
    }

    void Update()
    {
        foreach(var i in materials){
            if(structures[0].Material == i.Key.Type && i.Value > 0){
                structures[0].AddResource(i.Key);
                if(i.Value == 1)materials.Remove(i.Key);
                else materials[i.Key]--;
            }
        }
        foreach(var i in structures){
            var x = i.Produce();
            materials[x] ++;
        }
    }
    public Satisfaction GetPoblationalHappiness(){
        int n = 0;
        foreach (var item in materials)
        {
            if(item.Key.Type == Architecture.Resource.Resources.Satisfaccion){
                n += item.Key.Units*item.Value;
                materials.Remove(item.Key);
            }
        }
        return new Satisfaction(n);
    }
}
