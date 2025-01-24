using UnityEngine;
using Architecture.Eqquipables;
using Architecture.Resource;

public class Animals : MonoBehaviour
{
    public int Damage;
    public int Aggressive;
    public IResource Food;
    public IEqquipable Bait;
    public bool Flag = false;//Bandera para indicar al game controler que el animal va al ataque

    private bool Attack(IEqquipable bait = null){
        //Falta el aumento de agresividad del bait
        int regulator = 11;
        if(bait != null && Atracted(bait)){
            Aggressive += 5;
            regulator = 16;
        }
        if(Aggressive%regulator > Random.Range(1,10)){
            return true;
        }
        return false;
    }
    private bool Atracted (IEqquipable bait){
        if(bait.Name == Bait.Name){
            return true;
        }
        return false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        IEqquipable bait = other.gameObject.GetComponent<IEqquipable>();
        if(Attack(bait)){
            Flag = true;
        }
    }
}
