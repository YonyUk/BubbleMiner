using UnityEngine;
using Architecture.Resource;

public class Plants : MonoBehaviour
{
    public IResource Oxygen;

    private int maxCapacity;
    private int counter;

    void GenerateOxygen(){
        if(Oxygen == null){
           // Oxygen = new
        }
    }

    void Start(){
        maxCapacity = Oxygen.Units;
        //Oxygen = new 
    }
    void FixedUpdate(){
        if(counter == 1000){
            GenerateOxygen();
            counter =  0;
        }
        else counter++;
    }




}
