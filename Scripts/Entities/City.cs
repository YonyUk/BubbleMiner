using System.Collections.Generic;
using Architecture.Structures;
//using Unity.VisualScripting;
using UnityEngine;
using Variables;
using IResource = Architecture.Resource.IResource;
using Resources = Architecture.Resource.Resources;

public class City : MonoBehaviour
{
    public List<GameObject> StructPrefabs;
    public List<IStructure<IResource>> structures;
	Alcaldia alcaldia { get; set; }
    Dictionary<IResource,int>materials;
    void Start()
    {
		structures = new List<IStructure<IResource>> ();
        materials = new Dictionary<IResource, int>();
        int radius = 0;
        int angle = 0;
        int cont = 0;
		alcaldia = ((GameObject)Instantiate (StructPrefabs [0], new Vector3 (), Quaternion.identity)).GetComponent<Alcaldia>();

        while(cont < 12)
        {
            AddSpawnZone(angle,radius);
            angle+=60;
            radius += Globals.VectorNormalizer;
            cont++;
        }
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
            if(item.Key.Type == Resources.Satisfaccion){
                n += item.Key.Units*item.Value;
                materials.Remove(item.Key);
            }
        }
        return new Satisfaction(n);
    }
    public void AddSpawnZone(int angle, int radius){
        GameObject g = new GameObject();
        g.AddComponent<SpawnStructure>();
        SpawnStructure s = g.GetComponent<SpawnStructure>();
        s.PrefabsStructs = StructPrefabs;
        s.angle = angle;
        s.radius = radius;
        Instantiate(g,transform.position,Quaternion.identity);
    }
}
