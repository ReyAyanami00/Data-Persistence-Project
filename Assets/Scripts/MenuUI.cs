using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
 
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void InputName(string s)
    {
        GameManager.Instance.userName = s;
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        GameManager.Instance.Save();
#else
    Application.Quit();

#endif
    }
}
