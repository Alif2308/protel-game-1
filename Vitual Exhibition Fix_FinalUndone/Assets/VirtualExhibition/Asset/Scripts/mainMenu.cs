using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   public void continuePlay()
   {
       SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
   }

   public void toMenuPlay()
   {
       SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void exitPlay()
   {
       Debug.Log("Quit");
       Application.Quit();
   }
}
