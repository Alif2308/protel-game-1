using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//using TMPro;
using System.Linq;

public class GetText : MonoBehaviour
{
    //koordinat dari tempat konten
    public Transform contentwindow;
    public GameObject TextDescriptions;
    private GameObject ini;
    private string file = "Uji_Deskripsi";

    private string fileLines;

    public void direktori(string dimana)
    {
        file = dimana;
    }

    public void adakan()
    {
        TextDescriptions.GetComponent<Text>().text = "";
        //ambil file dari file directori file
        string readFile = Application.streamingAssetsPath + "/Recall_Deskripsi/" + file + ".txt"; // http localhost hillangkan kalau build dalam bentuk app/standalone

        /*List<string>*/ fileLines = File.ReadAllText(readFile);//.ToList(); //pakai ReadAllText kalau mau langsung tanpa harus per baris (ReadAllLines)
        TextDescriptions.GetComponent<Text>().text = fileLines;
        ini = Instantiate(TextDescriptions, contentwindow);
        
        

        /*foreach(string line in fileLines)
        {
            Instantiate(TextDescriptions, contentwindow);
            TextDescriptions.GetComponent<Text>().text += line;
            
        }*/
    }
    public void hilangkan()
    {
        //TextDescriptions.GetComponent<Text>().text = "";
        Destroy(ini,1.0f);
    }
    

}
