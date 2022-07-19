using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class selectionManager : MonoBehaviour
{
    //[SerializeField] private Material highlightMaterial;
    //[SerializeField] private Material defaultMaterial;
    [SerializeField] private string  selectabletag = "Selectable";
    [SerializeField] private string  pilihan = null;

    //public interactable Focus;

    public Color initialColor;
    public Color onHoverColor;
    public Color onClickColor;
    public static string selectedObject;
    public string internalObject;
    public UnityEvent _event = new UnityEvent();
    private Transform _selection;
    
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material.SetColor("_Color",initialColor);
            //defaultMaterial.color = Color.white;
            _selection = null;
            selectedObject = null;
            internalObject = null;
            //RemoveFocus();
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,8) && !EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log(hit.transform.name);
            //Debug.Log("hit");
            var selection = hit.transform;
            if (selection.CompareTag(selectabletag) && Cursor.visible == true)
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                selectedObject = selection.gameObject.name;
                internalObject = selection.gameObject.name;
                if (selectionRenderer != null)
                {
                    //defaultMaterial.color = Color.yellow;
                    selectionRenderer.material.SetColor("_Color",onHoverColor);
                    if(Input.GetMouseButtonDown(0))
                    {
                        selectionRenderer.material.SetColor("_Color",onClickColor);
                        Debug.Log("anda memilih:"+ internalObject);
                        
                        if(internalObject == pilihan)
                        {
                             _event.Invoke();
                        }
                        
                    }
                }
                _selection = selection;

                
            }
        }
    }
}
