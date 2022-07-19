using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hyperlink : MonoBehaviour
{
    [SerializeField] private string link = null;
    
    public void thelink(string urle)
    {
        link = urle;
    }
    public void openLinnk()
    {
        Application.OpenURL(link);
    }
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
   // }
}
