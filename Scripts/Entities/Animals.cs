using UnityEngine;
using Architecture.Eqquipables;
using Architecture.Resource;

public class Animals : MonoBehaviour
{
    public int Damage;
    public int Aggressive;
	public float Speed;
    public IResource Food;
    public IEqquipable Bait;
    public bool Attaking = false;//Bandera para indicar al game controler que el animal va al ataque
	public bool Running = false;
	public int Life { get; private set; }

    private bool CanAttack(IEqquipable bait){
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
    //Falta el Drop De jama
    void OnCollisionEnter(Collision other)
    {
        IEqquipable bait = other.gameObject.GetComponent<IEqquipable>();
        if(CanAttack(bait)){
            Attaking = true;
        }
    }
}
