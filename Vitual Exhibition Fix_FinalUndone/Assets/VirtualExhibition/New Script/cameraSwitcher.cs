using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class cameraSwitcher : MonoBehaviour
{
    [SerializeField] InputAction action;
    [SerializeField] CinemachineVirtualCamera FirstPersonCam;
    [SerializeField] int FirstPersonCamPriority = 1;
    [SerializeField] CinemachineFreeLook ThirdPersonCam;
    [SerializeField] int ThirdPersonCamPriority = 0;
    private bool is_FPC = true;

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        action.performed += _ => SwitchCamera();
    }

    private void SwitchCamera()
    {
        if(is_FPC)
        {
            FirstPersonCam.Priority = FirstPersonCamPriority;
            ThirdPersonCam.Priority = ThirdPersonCamPriority;
        }
        else
        {
            FirstPersonCam.Priority = ThirdPersonCamPriority;
            ThirdPersonCam.Priority = FirstPersonCamPriority;
        }
        is_FPC = !is_FPC;
    }
}
