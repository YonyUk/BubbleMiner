using UnityEngine;
using Architecture.Resource;

public class Plants : MonoBehaviour
{
    public int units;
    public IResource Oxygen;
    private int counter;

    void GenerateOxygen(){
        if(Oxygen == null){
           Oxygen = new Oxigen(1);
        }
        else if(Oxygen.Units < units) Oxygen = new Oxigen(Oxygen.Units + 1);
        
    }   

    void Start(){
        Oxygen = new Oxigen(units);
    }
    void FixedUpdate(){
        if(counter == 1000){
            GenerateOxygen();
            counter =  0;
        }
        else counter++;
    }




}
