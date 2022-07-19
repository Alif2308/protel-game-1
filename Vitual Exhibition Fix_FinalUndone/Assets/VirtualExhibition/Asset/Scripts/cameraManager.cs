using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class cameraManager : MonoBehaviour
{
    public UnityEvent _event = new UnityEvent();
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //bool klik_c = Input.GetKey("c");
        if(Input.GetKeyDown("c"))
        {
            _event.Invoke();
            gameObject.SetActive(false);
            //klik_c = !klik_c;

        }
    }
}
