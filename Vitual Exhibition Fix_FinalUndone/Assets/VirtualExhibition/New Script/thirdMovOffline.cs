using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class thirdMovOffline : MonoBehaviour //MonoBehaviour di ganti NetworkBehavior kalau mau  multip clone
{
    public CharacterController controller; // mengambil CharacterController sebagai variable controller
    private Transform cam; // transformasi kamera
    [SerializeField] private GameObject player_camera; // objek kamera (untuk multiplayer)
    public float speed = 2f;

    public float turnSmoothTime = 0.1f; // waktu transisi rotasi
    float turnSmoothVelocity; // refernsi penyimpanan nilai

    Vector3 velocity; //referensi kecepatan untuk gravitasi
    public float gravity = -9.8f;
    public Transform groundCheck; //groundcheck
    public float groundDistance = 0.4f; //colloder radius
    public LayerMask groundMask; // fungsinya seperti tag namun menggunakan layer
    private bool isGrounded;

    private void Update()
    {
        //if(!hasAuthority) {return;}

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool sedanglari = Input.GetKey("left shift");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //(x,y,z)

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;  // fungsi mathematis untuk mengembalikan axis x start pada titik 0 dan berhenti pada x,y
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // for smooth rotation transisiton
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if(sedanglari)
            {
                controller.Move(moveDir.normalized * (speed * 3) * Time.deltaTime);
            }
            else
            {
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }
            
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
