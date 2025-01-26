using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public capsuleController cc;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("cup", cc.playerIn);
    }
    public void Init()
    {
        print("init");
        anim.SetTrigger("init");
    }
}
