using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class selectableObjectColor : MonoBehaviour
{
    //[SerializeField] private Material defaultMaterial;
    private Transform _selection;
    private void update(Collider other)
    {
        
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            _selection = null;
            //defaultMaterial.color = Color.white;
        }
        var rayc = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit ada;
        if(Physics.Raycast(rayc,out ada,100))
        {
            var selection = ada.transform;
            if(other.CompareTag("Player"))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    //defaultMaterial.color = Color.yellow;
                }
                _selection = selection;
            }
            
            
        }
        
    }

}
