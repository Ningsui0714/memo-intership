
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpScenes : MonoBehaviour
{
    public void jumptoplayscene(string sceneName)
    {
        SceneManager.LoadScene(1);//1和下面的0表示场景的编号
    }
 
}
                          