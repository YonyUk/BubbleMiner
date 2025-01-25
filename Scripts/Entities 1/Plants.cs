using UnityEngine;
using Architecture.Resource;

public class Plants : MonoBehaviour
{
    public int units;
    public IResource Oxygen;
    private float counter;

    void GenerateOxygen()
    {
        if (Oxygen == null)
        {
            Oxygen = new Oxigen(1);
        }
        else if (Oxygen.Units < units) Oxygen = new Oxigen(Oxygen.Units + 1);

    }

    void Start()
    {
        Oxygen = new Oxigen(units);
    }
    void Update()
    {
        if (counter > 15)
        {
            GenerateOxygen();
            counter = 0;
        }
        else counter += Time.deltaTime;
    }




}
