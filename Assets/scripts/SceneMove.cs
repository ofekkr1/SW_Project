using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    
    public void MoveScene()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            
            case 0:
                SceneManager.LoadScene(sceneName: "options");
                break;

            default:
                SceneManager.LoadScene(sceneName: "SampleScene");
                break;
        }
       
    }
}
