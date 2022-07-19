using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class controlPlayer : MonoBehaviour
{
    //Playercontroller input;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameratransform;
    //private bool stateCam = false;
    private Vector2 movement;
    //[SerializeField] private InputActionReference movementControl;
    //[SerializeField] private InputActionReference jumpControl;
    Animator animator;
    int isWalkingHash; 
    int isRunningHash;
    [SerializeField] private GameObject Rigbody;
    [SerializeField] private float playerSpeed = 2.0f; // [SerializeField] biar bisa diliat di inspector
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationspeed = 4f;
    [SerializeField] private float raycastDistance;

    public StandChangerButton standChangerButton;

    /*private void Awake()
    {
        //input = new Playercontroller();
    }*/


    private void Start()
    {
        animator = Rigbody.GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        //controller = gameObject.AddComponent<CharacterController>(); // untuk nambah componen secara otomatis *MAGIC*
        controller = gameObject.GetComponent<CharacterController>(); //untuk ambil value dari suatu componen yang telah di buat manual
        inputManager = InputManager.Instance;
        cameratransform = Camera.main.transform;
    }

    void Update()
    {
        bool sedangjalan = animator.GetBool(isWalkingHash);
        bool sedanglari = animator.GetBool(isRunningHash);
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        /*if(stateCam == true)
        {
            movement = movementControl.action.ReadValue<Vector2>(); //sebenarnya sama seperti yang bawah tapi beda metode
        }*/
        //if(stateCam == false)
        //{
            movement = inputManager.GetPlayerMovement(); //sebenarnya sama seperti yang atas tapi beda metode
        //}
        Vector3 move = new Vector3(movement.x, 0f, movement.y); // koordinat xyz, z kosong karena buat gerak vertikal (tergantung arah bendanya se)
        move = cameratransform.forward * move.z + cameratransform.right * move.x; // karena di unity arah horizontalnya berdasarkan koordinat kartesian x dan z (y keatas lur)
        move.y=0f;
  //controller.Move(move * Time.deltaTime * playerSpeed);
        if(inputManager.PlayerSprint())
        {
            controller.Move(move * Time.deltaTime * (playerSpeed * 3));
        }
        else
        {
            controller.Move(move * Time.deltaTime * playerSpeed);
        }
        

        /*if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }*/

        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameratransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f,targetAngle,0f);
            transform.rotation = Quaternion.Lerp(transform.rotation,rotation,Time.deltaTime*rotationspeed);
        }

        // Changes the height position of the player..
        /*if (inputManager.PlayerJumpThisFrame() && groundedPlayer) // bisa pakai jumpControl.action.Triggered jika tidak ingin pakai inputManager.PlayerJumpThisFrame()
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }*/

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(!sedangjalan)
        {

        }

        raycast();
    }

    void raycast()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastDistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            

            if (hit.transform.CompareTag("Button"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    standChangerButton.Switcher();
                    Debug.Log("Stand Switched");
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
    }
}
