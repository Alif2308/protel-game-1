using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class SimpanUlasan : MonoBehaviour
{
    public TMP_InputField input_feedback;

    //[SerializeField] private string IsiRating;
    private string rating_nya = "0";

    //public Inpu
    void Start()
    {
        //buat folder
        Directory.CreateDirectory(Application.streamingAssetsPath + "/Hasil_Feedback/");
    }

    public void rating(string the_rating)
    {
        // untuk menyimpan nilai rating
        rating_nya = the_rating;
    }

    public void BuatUlasan()
    {
        //men-check apakah ada isian di feedback atau tidak, jika kosong maka tidak mengganti isi file yang sudah ada
        if(input_feedback.text == "")
        {
            return;
        }
        //membuat txt file daam folder yang telah di buat
        string namaFile = Application.streamingAssetsPath + "/Hasil_Feedback/" + "feedback" + ".txt"; //nanti di ganti UID kalau sudah online

        // cek file apakah sudah ada atau belum, kalau belum buat baru, kalau ada skip
        if(!File.Exists(namaFile))
        {
            // coba passing nilai rating sebagai header
            File.WriteAllText(namaFile,"RATING: " + rating_nya +"\n\n" + input_feedback.text + "\n");

        }
        else
        {
            File.WriteAllText(namaFile,"RATING: " + rating_nya +"\n\n" + input_feedback.text + "\n");
        }

        //append isi dari file untuk menambahi isian (opsional)
        //File.AppendAllText(namaFile, input_feedback.text + "\n");
    }
}
