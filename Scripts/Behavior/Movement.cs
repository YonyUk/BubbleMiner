using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

public class Movement : MonoBehaviour
{
    Camera mainCamera;
    public float speed;
    private void Move(){
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 direction = new(inputHorizontal, 0, inputVertical);

        Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));
        Vector3 fixedDirection = matrix.MultiplyVector(direction);  
        fixedDirection.Normalize();
        if(Input.GetKey(KeyCode.LeftShift)) speed = 2.8f;
        else speed = 1.5f;
        GetComponent<CharacterController>().Move(fixedDirection * 4 * Time.deltaTime * speed);

    }
    
    private void LookAtCursor(){
        var mousePos = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 direction;
        if(Physics.Raycast(mousePos, out var hitInfo, Mathf.Infinity, 1)){
            if(hitInfo.transform.CompareTag(Globals.playerTag)) direction = new(1,0,1);
            else direction = hitInfo.point - transform.position;
            direction.y = 0;
        }
        else {
            direction = Vector3.forward ;
        }

        transform.forward = direction;
    }
     
    void Start()
    {
        mainCamera = Camera.main;
        speed = 1.5f;
    } 



    // Update is called once per frame
    void Update()
    {
        Move();
        LookAtCursor();
    }
}
