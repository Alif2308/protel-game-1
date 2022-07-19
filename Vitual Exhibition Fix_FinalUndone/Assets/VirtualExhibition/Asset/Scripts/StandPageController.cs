using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandPageController : MonoBehaviour
{
    public int currentPage = 0;

    [System.Serializable]
    public class PageStand{
        // public string namaPage = "page";
        public bool available;
        public GameObject[] stands;


        public void SetPage(bool setstatus){
            for(int i = 0; i < stands.Length; i++){
                stands[i].SetActive(setstatus);
            }
        }
    }

    public PageStand[] page;

    public Transform player;
    public float minDist = 3f;
    public float distance = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdatePage();
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position,player.position);

        if( Vector3.Distance(transform.position,player.position) < minDist){
            if(Input.GetKeyDown(KeyCode.F)){
                NEXT_PAGE();
            }
        }
    }

    public void UpdatePage(){
        for(int i = 0 ; i < page.Length; i++){
            page[i].SetPage(i == currentPage);
        }
    }

    public void NEXT_PAGE(){
        if(currentPage+1 >= page.Length ){
            currentPage = 0;
        }else{
            currentPage++;
        }

        UpdatePage();

    }

    public void PREV_PAGE(){
        if(currentPage < 0){
            currentPage = page.Length-1;
        }else{
            currentPage--;
        }

        UpdatePage();
    }



    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.tag == "Player"){
    //         NEXT_PAGE();
    //     }

    //     Debug.Log("MASUKK LUURR");
    // }

}
