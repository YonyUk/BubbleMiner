using System.Collections.Generic;
using Architecture.Structures;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;


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
    AlmacenDeBurbujas burbujas { get; set; }
    AlmacenDeComida almacenDeComida { get; set; }
    Condominio condominio { get; set; }
    public int oxigen = 20;
    public int satisfaction = 100;
    public int food = 20;
    public int people = 5;
    void Start()
    {
        structures = new List<IStructure>();
        int radius = 0;
        int angle = 0;
        int cont = 0;
        alcaldia = ((GameObject)Instantiate(StructPrefabs[0], new Vector3(), Quaternion.identity)).GetComponent<Alcaldia>();
        burbujas = ((GameObject)Instantiate(StructPrefabs[1], new Vector3(), Quaternion.identity)).GetComponent<AlmacenDeBurbujas>();
        almacenDeComida = ((GameObject)Instantiate(StructPrefabs[2], new Vector3(), Quaternion.identity)).GetComponent<AlmacenDeComida>();
        condominio = ((GameObject)Instantiate(StructPrefabs[3], new Vector3(), Quaternion.identity)).GetComponent<Condominio>();
        structures.Add(alcaldia);
        structures.Add(burbujas);
        structures.Add(almacenDeComida);
        structures.Add(condominio);
        while (cont < 6)
        {
            AddSpawnZone(angle, radius);
            angle += 60;
            radius = Globals.VectorNormalizer;
            cont++;
        }
    }
    void GetParams(Architecture.Resource.Resources type, int units)
    {
        switch (type)
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

    public void NextDay()
    {
        if (oxigen >= people) oxigen -= people;
        else oxigen = 0;
        if (food >= people) food -= people;
        else food = 0;
        if (satisfaction >= people) satisfaction -= people;
        else satisfaction = 0;
        structures[3].AddResource(new People(people));
        foreach (var i in structures)
        {
            i.Produce(GetParams);
        }
    }
    public void AddSpawnZone(int angle, int radius)
    {
        GameObject g = new GameObject();
        g.AddComponent<SpawnStructure>();
        SpawnStructure s = g.GetComponent<SpawnStructure>();
        s.PrefabsStructs = StructPrefabs;
        s.angle = angle;
        s.radius = radius;
        Instantiate(g, transform.position, Quaternion.identity);
    }
    public void ManageStorage(int oxygen, int food)
    {
        structures[1].AddResource(new Oxigen(oxygen));
        structures[2].AddResource(new Food(food));
    }
}
