using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class harpoonBar : MonoBehaviour
{
    public Transform padre;
    public Harpoon h;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void get()
    {
        if (!h.loaded)
        {
            transform.SetParent(padre);
            transform.SetAsFirstSibling();
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<Rigidbody>().isKinematic = true;

        }
    }
}
