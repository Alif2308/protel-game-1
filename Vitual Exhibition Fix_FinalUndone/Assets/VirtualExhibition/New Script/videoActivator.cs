using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class videoActivator : MonoBehaviour
{
    public UnityEvent on_coll = new UnityEvent();
    public UnityEvent out_coll = new UnityEvent();
    [SerializeField] private string objek;
    
    // Start is called before the first frame update

    void inCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Camera_testing")
        {
            on_coll.Invoke();
        }
    }
    void inCollisionExit(Collision col)
    {

    }
   
}
