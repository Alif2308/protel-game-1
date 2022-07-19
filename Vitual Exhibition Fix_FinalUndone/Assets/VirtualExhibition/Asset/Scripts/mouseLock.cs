using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mouseLock : MonoBehaviour //NetworkBehaviour //monobehaviour buat offline networkbehaviour buat online
{

    [SerializeField] private bool visibility = default;
    [SerializeField] private UnityEvent on_mouse_lock = new UnityEvent();
    [SerializeField] private UnityEvent on_mouse_unlock = new UnityEvent();

    void Update()
    {
        //if(isLocalPlayer) 
        //{
            if (visibility == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                on_mouse_lock.Invoke();
            }
            if (Input.GetKeyDown("tab"))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                visibility =!visibility;
                on_mouse_unlock.Invoke();
            }
        //}


        
    }
    public void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
