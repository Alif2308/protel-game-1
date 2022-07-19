using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance
    {
        get
        {return _instance;}
    }

    private Playercontroller playercontrols;  //referensi ke script playercontroller (ingat di C# selalu di awali dengan huruf besar)

    private void Awake()    // ketika mulai
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playercontrols = new Playercontroller();
    }

    private void OnEnable()     //ketika ada atau script ini jalan
    {
        playercontrols.Enable();
    }

    private void OnDisable() //ketika mati atau script tidak dipakai jalan
    {
        playercontrols.Disable();
    }

    /* helper function agar suatu objek tidak perlu menjalankan semua program pada script ini dan memudahkan dalam
    passing fungsi yang diperlukan objek dalam script ini (ada di bawah vvvvvv) */

    public Vector2 GetPlayerMovement()
    {
        return playercontrols.player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playercontrols.player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpThisFrame()
    {
        return playercontrols.player.Jump.triggered;
    }

    public bool PlayerSprint()
    {
        return playercontrols.player.Sprint.triggered;
    }
}
