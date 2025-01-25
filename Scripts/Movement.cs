using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;

public class Movement : MonoBehaviour
{
    public Animator anim;
    [HideInInspector]
    public bool moving;
    public bool mining;
    public float MovementSpeed;
    Camera mainCamera;
    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 direction = new(inputHorizontal, 0, inputVertical);
        direction.Normalize();

        moving = direction.magnitude > 0;
        if (!mining)
            GetComponent<CharacterController>().Move(direction * MovementSpeed * Time.deltaTime);

    }
    void AnimationHandler()
    {
        anim.SetBool("run", moving);

        anim.SetBool("mine", mining);
    }
    void Mining()
    {
        mining = Input.GetMouseButton(0);
    }
    private void LookAtCursor()
    {
        var mousePos = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = transform.forward;
        if (Physics.Raycast(mousePos, out var hitInfo, Mathf.Infinity, 1))
        {
            if (hitInfo.transform.CompareTag(Globals.playerTag))
            {
                direction = new Vector3(1, 0, 1);
            }
            else
            {
                direction = hitInfo.point - transform.position;
                direction.y = 0;
            }
        }

        // Suavizar el giro utilizando SmoothDamp
        Vector3 currentDirection = transform.forward;
        if (mining)
        {
            Vector3 smoothDirection = Vector3.SmoothDamp(currentDirection, direction, ref currentVelocity, smoothTime + 2);
            transform.forward = smoothDirection;

        }
        else
        {
            Vector3 smoothDirection = Vector3.SmoothDamp(currentDirection, direction, ref currentVelocity, smoothTime);
            transform.forward = smoothDirection;

        }
    }

    // Variables para SmoothDamp
    private Vector3 currentVelocity = Vector3.zero;
    public float smoothTime = 0.3f; // Ajusta este valor según tus necesidades


    void Start()
    {
        mainCamera = Camera.main;
    }



    // Update is called once per frame
    void Update()
    {
        Mining();
        Move();
        LookAtCursor();
        AnimationHandler();
    }
}
