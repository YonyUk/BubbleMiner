using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Variables;
using Architecture.Eqquipables;
using Unity.VisualScripting;
public class Movement : MonoBehaviour
{
    public static Movement mov;

    public IEqquipable gun;
    public int gunIndex = 0;
    public harpoonBar hbar;
    public BubbleCollector BbGun;
    public Harpoon harpoon;
    public Drill drill;
    public bool shooting;

    public int oxygenStorage = 0;
    public int foodStorage = 0;
    public int drillStorage = 0;

    public Animator anim;
    [HideInInspector]
    public bool moving;
    public bool mining;
    public float MovementSpeed;
    Camera mainCamera;
    public float oxigen = 1;
    public float MultiOxigen = 1;
    bool pick;
    public LayerMask layer;
    public City city;
    void Awake()
    {

        if (!mov)
        {
            mov = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void SwitchGun()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            gunIndex++;
            if (gunIndex > 2)
            {
                gunIndex = 0;
            }
            switch (gunIndex)
            {
                case 0:
                    gun = BbGun;
                    break;
                case 1:
                    gun = harpoon;
                    break;
                case 2:
                    gun = drill;
                    break;

            }
        }
    }
    void Died()
    {
        if (oxigen <= 0)
        {
            GetComponent<CharacterController>().enabled = false;

            // Transportar el personaje a la coordenada (0, 0, 0)
            transform.position = Vector3.zero;

            // Reactivar el CharacterController
            GetComponent<CharacterController>().enabled = true;
            oxygenStorage = 0;
            foodStorage = 0;
            drillStorage = 0;
            oxigen = 0.98f;
        }

    }
    private void UpdateStorage()
    {

        oxygenStorage = BbGun.occupied;
        drillStorage = drill.occupied;


    }
    public bool InCity()
    {
        return capsuleController.capsula.playerIn;
    }
    private void Oxigen()
    {
        if (InCity())
        {
            if (oxigen <= 1)
                oxigen += Time.deltaTime / 5;
        }
        else
        {
            if (oxigen > 0)
                oxigen -= Time.deltaTime / (MultiOxigen * 100);
        }
    }
    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 direction = new(inputHorizontal, 0, inputVertical);
        direction.Normalize();

        moving = direction.magnitude > 0;
        shooting = anim.GetCurrentAnimatorStateInfo(0).IsName("harpon");

        if (!mining && !shooting)
            GetComponent<CharacterController>().Move(direction * MovementSpeed * Time.deltaTime);

    }
    void AnimationHandler()
    {
        anim.SetBool("run", moving);
        anim.SetInteger("gun", gunIndex);
        anim.SetBool("mine", mining);
    }
    void Mining()
    {
        mining = Input.GetMouseButton(0);
        if (mining)
        {
            gun.Use();
        }
    }
    private void LookAtCursor()
    {
        var mousePos = mainCamera.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = transform.forward;
        if (Physics.Raycast(mousePos, out var hitInfo, Mathf.Infinity, layer))
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
        if (shooting)
        {
            Vector3 smoothDirection = Vector3.SmoothDamp(currentDirection, direction, ref currentVelocity, smoothTime / 2);
            transform.forward = smoothDirection;

        }
        else
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
        gun = BbGun;
    }



    // Update is called once per frame
    void Update()
    {
        Died();
        if (InCity() && !pick)
        {
            pick = true;

            hbar.get();
        }
        else if (!InCity())
        {
            pick = false;
        }
        SwitchGun();
        UpdateStorage();
        Oxigen();
        Mining();
        if (GameManager.instance.start)
            Move();
        LookAtCursor();
        AnimationHandler();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Globals.harpoonlBarTag))
        {
            other.GetComponent<harpoonBar>().get();
            harpoon.loaded = true;
            harpoon.flag = false;
        }
        if (other.CompareTag(Globals.foodTag))
        {
            foodStorage += other.GetComponent<Meat>().unit;
            Destroy(other.gameObject);

        }
    }
}
