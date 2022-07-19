using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using Mirror;
public class objectClick : MonoBehaviour
{
    public UnityEvent _event = new UnityEvent();
    private GameObject _tombol;
    // Start is called before the first frame update
    void Start()
    {
        _tombol = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Input.GetMouseButton(0))
            {
                if (Physics.Raycast(ray,out hit,8) && hit.collider.gameObject == gameObject)
                {
                    _event.Invoke();
                }
            }
        }
        
    }
}
