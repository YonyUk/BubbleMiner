using UnityEngine;
using Architecture.Eqquipables;
using Architecture.Resource;
using Variables;

public class Animals : MonoBehaviour
{
    public int Damage;
    public float Speed;
    public bool Running = false;
    public int healthpoints;
    public int Aggressive;
    public IResource Food;
    public IEqquipable Bait;
    public bool Attaking = false;//Bandera para indicar al game controler que el animal va al ataque
    public bool isLooted = false;
    public GameObject food;
    private bool CanAttack(IEqquipable bait)
    {
        //Falta el aumento de agresividad del bait
        int regulator = 11;
        if (bait != null)//&& Atracted(bait))
        {
            Aggressive += 5;
            regulator = 16;
        }
        if (Aggressive % regulator > Random.Range(1, 10))
        {
            return true;
        }
        return false;
    }
    // private bool Atracted(IEqquipable bait)
    // {
    //     if (bait.Name == Bait.Name)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
    void TakeDamage(int damage)
    {
        healthpoints -= damage;
        if (healthpoints <= 0) Die();
    }

    void Die()
    {
        Instantiate(food, transform.position, Quaternion.identity, null);
        //food.GetComponent<Meat>().unit = Food.Units;
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag(Globals.harpoonlBarTag))
        {
            print("damage");
            TakeDamage(other.transform.GetComponentInParent<harpoonBar>().damage);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        IEqquipable bait = other.gameObject.GetComponent<IEqquipable>();
        if (CanAttack(bait))
        {
            Attaking = true;
        }
    }
    void Start()
    {
        healthpoints = 1;
        Food = new Food(8);
    }
}
