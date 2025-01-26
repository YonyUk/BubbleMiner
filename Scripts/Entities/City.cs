using System.Collections.Generic;
using Architecture.Structures;
using Unity.Burst.Intrinsics;

//using Unity.VisualScripting;
using UnityEngine;
using Variables;
using IResource = Architecture.Resource.IResource;
using Resources = Architecture.Resource.Resources;

public class City : MonoBehaviour
{
    public List<GameObject> StructPrefabs;
    public List<IStructure> structures;
	Alcaldia alcaldia { get; set; }
    AlmacenDeBurbujas burbujas {get;set;}
    AlmacenDeComida almacenDeComida{get;set;}
    Condominio condominio {get;set;}
    Dictionary<IResource,int>materials;
    public int oxigen = 20;
    public int satisfaction = 100;
    public int food=20;
    public int people=5;    
    void Start()
    {
		structures = new List<IStructure> ();
        materials = new Dictionary<IResource, int>();
        int radius = 0;
        int angle = 0;
        int cont = 0;
		alcaldia = ((GameObject)Instantiate (StructPrefabs [0], new Vector3 (), Quaternion.identity)).GetComponent<Alcaldia>();
        burbujas = ((GameObject)Instantiate(StructPrefabs[1], new Vector3(),Quaternion.identity)).GetComponent<AlmacenDeBurbujas>();
        almacenDeComida = ((GameObject)Instantiate(StructPrefabs[2],new Vector3(),Quaternion.identity)).GetComponent<AlmacenDeComida>();
        condominio = ((GameObject)Instantiate(StructPrefabs[3],new Vector3(),Quaternion.identity)).GetComponent<Condominio>();
		structures.Add (alcaldia);
        structures.Add(burbujas);
        structures.Add(almacenDeComida);
        structures.Add(condominio);
        while(cont < 6)
        {
            AddSpawnZone(angle,radius);
            angle+=60;
            radius = Globals.VectorNormalizer;
            cont++;
        }
    }
	void GetParams(Architecture.Resource.Resources type,int units){
		switch(type)
        {
            case Resources.Oxygen:
                oxigen += units;
                break;
            case Resources.Food:
                food += units;
                break;
            case Resources.Satisfaccion:
                satisfaction += units;
                break;
            case Resources.People:
                people += units;
                break;
            default:
                return;
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
            i.Produce(GetParams);
            //materials[x] ++;
        }
    }

    public void NextDay()
    {
            oxigen -= people;
            food -= people;
            satisfaction -= people;
            structures[4].AddResource(new People(people));
            structures[4].Produce(GetParams);
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
