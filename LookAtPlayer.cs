using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public FishBrain fb;
    void Update()
    {
        if (fb.Attaking)
        {
            transform.LookAt(Movement.mov.transform.position);
            transform.Rotate(0, 90, 0);

        }
    }
}
