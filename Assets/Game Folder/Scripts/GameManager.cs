using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    bool gameHasEnded = false;
    AnimationController animationController;
    

    
    

    private void Start()
    {
        animationController = FindObjectOfType<AnimationController>();
    }

    public void EndGame()
    {
        animationController.SetFallTrue();
        StartCoroutine(UIPause(2.0f));
    }

    public IEnumerator UIPause(float pauseTime)
    {
        yield return new WaitForSeconds(pauseTime);
        gameOverScreen.SetUp();
    }

}

    

