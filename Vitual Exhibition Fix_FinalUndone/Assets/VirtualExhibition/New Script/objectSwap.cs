using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class objectSwap : MonoBehaviour
{
    [SerializeField] private UnityEvent _event_in = new UnityEvent();
    [SerializeField] private UnityEvent _event_out = new UnityEvent();
    [SerializeField] private GameObject objek_init;
    [SerializeField] private GameObject objek_swap;
    private bool  awake;
    void Start()
    {
        awake = true;
        objek_init.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(objek_init.activeSelf == true)
        {
            _event_in.Invoke();
        }
        else
        {
            _event_out.Invoke();
        }
    }
}
