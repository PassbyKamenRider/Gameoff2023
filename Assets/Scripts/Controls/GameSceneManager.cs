using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadScene(int num)
    {
        switch(num)
        {
            case 0:
                SceneManager.LoadScene("Level1");
                break;
            
            default:
                break;
        }
    }
}
