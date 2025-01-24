using UnityEngine;

public class Animals : MonoBehaviour
{
    public int Damage;
    public int Aggressive;
    public GameObject food;
    public GameObject Bait; //Tiene que ser un IEquipable

    public Animals(int Damage,int Aggressive, GameObject Bait){
        this.Damage = Damage;
        this.Aggressive = Aggressive;
        this.Bait = Bait;
    }
    public bool Attack(int regulator = 11){
        //Falta el aumento de agresividad del bait
        if(Aggressive%regulator > Random.Range(1,10)){
            return true;
        }
        return false;
    }
    public GameObject Drop(){

    }
}
