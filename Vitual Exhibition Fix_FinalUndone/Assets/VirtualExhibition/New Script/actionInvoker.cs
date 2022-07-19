using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class actionInvoker : MonoBehaviour
{
    [SerializeField] InputAction action;
    private UnityEvent _event = new UnityEvent();


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
        action.performed += _ => invoke_action();
    }

    private void invoke_action()
    {
        _event.Invoke();
    }

}
