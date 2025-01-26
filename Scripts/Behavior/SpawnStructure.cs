using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.ShaderGraph;
//using UnityEngine.InputSystem;
using Architecture.Structures;
using Architecture.Resource;
public class SpawnStructure : MonoBehaviour
{
    
    public List<GameObject>PrefabsStructs;
    public float radius; // El radio
    public float angle;  // El ángulo en grados
    bool FlagCollider =false;
    public int index = -1;

    void Start()
    {
        // Convertir el ángulo de grados a radianes
        float angleInRadians = angle * Mathf.Deg2Rad;
        
        // Calcular las coordenadas cartesianas
        float x = radius * Mathf.Cos(angleInRadians);
        float y = radius * Mathf.Sin(angleInRadians);
        
        // Asignar la posición del objeto
        transform.position = new Vector3(x, y, 0);
        
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.C) && FlagCollider){
            GameObject g = GetStruct(index = IndexStruct());
            this.GetComponentInParent<City>().structures.Add(g.GetComponent<IStructure<IResource>>());
            Instantiate(g,transform.position,Quaternion.identity);
        }
    }
    GameObject GetStruct(int x)
    {
        if(x == -1)return null;
        return PrefabsStructs[x];
    }
    int IndexStruct(){
        if(Input.GetKey(KeyCode.Alpha0))return 0;
        if(Input.GetKey(KeyCode.Alpha1))return 1;
        if(Input.GetKey(KeyCode.Alpha2))return 2;
        if(Input.GetKey(KeyCode.Alpha3))return 3;
        /*if(Input.GetKey(KeyCode.Alpha4))return 4;
        if(Input.GetKey(KeyCode.Alpha5))return 5;
        if(Input.GetKey(KeyCode.Alpha6))return 6;
        if(Input.GetKey(KeyCode.Alpha7))return 7;
        if(Input.GetKey(KeyCode.Alpha8))return 8;
        if(Input.GetKey(KeyCode.Alpha9))return 9;*/
        else return -1;
        
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")FlagCollider =true;
    }
     void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Player")FlagCollider =false;
    }
}
