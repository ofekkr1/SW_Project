using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Move_To_Tutorial : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene(sceneName: "How_To_Play");
    }
}
