using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string SceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public void PlayGame(){
       Debug.Log("play");
        playerStorage.initialValue = playerPosition;
        SceneManager.LoadScene (SceneToLoad);
   }

   public void QuitGame(){
       Debug.Log("quit");
       Application.Quit();
   }
}
