using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManeger : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Star()
    {
        anim.SetTrigger("start");
    }
}
