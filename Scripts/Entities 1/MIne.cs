using System.Collections;
using System.Collections.Generic;
using Architecture.Resource;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public int units;
    public IResource Mineral;
    private float counter;

    void GenerateMineral()
    {
        if (Mineral == null)
        {
            Mineral = new Mineral(1);
        }
        else if (Mineral.Units < units) Mineral = new Mineral(Mineral.Units + 1);

    }

    void Start()
    {
        Mineral = new Mineral(units);
    }
    void Update()
    {
        if (counter > 15)
        {
            GenerateMineral();
            counter = 0;
        }
        else counter += Time.deltaTime;
    }


}
