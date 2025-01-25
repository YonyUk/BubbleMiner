using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubblePartAbsorsion : MonoBehaviour
{
    public ParticleSystem bubbles;
    public BubbleCollector gun;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gun.canUse && !flag)
        {
            bubbles.Play();
            flag = true;
        }
        else if (!gun.canUse)
        {
            bubbles.Stop();
            flag = false;
        }
    }
}
