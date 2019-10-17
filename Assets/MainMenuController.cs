using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
   public void SwitchScene(int index = 0) {
       SceneManager.LoadScene(index); 
   }

   public void EndGame () {
       Debug.Log ("QUITTING!");
       Application.Quit();
   }

}
