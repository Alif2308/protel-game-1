using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorOffline : MonoBehaviour
{
    [SerializeField] private GameObject Rigbody;
    Animator animator;
    int isWalkingHash; 
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = Rigbody.GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
            bool sedangjalan = animator.GetBool(isWalkingHash);
            bool sedanglari = animator.GetBool(isRunningHash);
            bool maju_w = Input.GetKey("w");
            bool maju_a = Input.GetKey("a");
            bool maju_s = Input.GetKey("s");
            bool maju_d = Input.GetKey("d");
            bool lari   = Input.GetKey("left shift");

            //jika di pencet tombol jalan
            if (!sedangjalan && (maju_w||maju_a||maju_s||maju_d))
            {
                // mengganti referensi menjadi true
                animator.SetBool(isWalkingHash,true);
            }
            //jika tombol jalan di realease
            if (sedangjalan && !(maju_w||maju_a||maju_s||maju_d))
            {
                // mengganti referensi menjadi false
                animator.SetBool(isWalkingHash,false);
            }

            /*
            // jika tidak lari dan tombol di tekan
            if (!sedanglari && ((maju_w||maju_a||maju_s||maju_d) && lari))
            {
                // mengganti referensi menjadi true
            animator.SetBool(isRunningHash,true);

            }
            
            //jika sedang lari dan tombol di release
            if (sedanglari && ((maju_w||maju_a||maju_s||maju_d) && !lari))
            {
                // mengganti referensi menjadi false
                animator.SetBool(isRunningHash,false);
            
            }
            if (sedanglari && (!(maju_w||maju_a||maju_s||maju_d) && lari))
            {
                // mengganti referensi menjadi false
                animator.SetBool(isRunningHash,false);
            
            }
            */
    }
}
