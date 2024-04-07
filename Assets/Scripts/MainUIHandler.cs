using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;


[DefaultExecutionOrder(1000)]
public class MainUIHandler : MonoBehaviour
{

    private void UpdateHighScore(int newHighest)
    {
        if (MainManager.Instance.m_Points > MainManager.Instance.m_Score)
        {
            MainManager.Instance.m_Score = MainManager.Instance.m_Points;
            newHighest = MainManager.Instance.m_Score;
            MainManager.Instance.BestScoreText.text = $"Best Score : {MainManager.Instance.m_Score}";
        }
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
