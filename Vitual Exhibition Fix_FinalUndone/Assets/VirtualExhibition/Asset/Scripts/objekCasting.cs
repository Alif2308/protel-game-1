//codingan referensi (tidak di pakai)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objekCasting : MonoBehaviour
{
    [SerializeField] private string  selectabletag = "Selectable";
    public static string selectedObject;
    public string internalObject;
    public RaycastHit object_nya;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var selection = object_nya.transform;
        if(selection.CompareTag(selectabletag))
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out object_nya))
            {
                selectedObject = selection.gameObject.name;
                internalObject = selection.gameObject.name;
            }
        }
        
    }
}
