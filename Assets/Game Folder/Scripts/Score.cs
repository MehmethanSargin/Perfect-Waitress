using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Text food1;
    [SerializeField]
    private Text food2;

    FinishCollision finishCollision;

    private void Start()
    {
        finishCollision = FindObjectOfType<FinishCollision>();
    }

    private void Update()
    {
       ////TODO: getting count from stack script for each food and add to score.
       // food1.text = finishCollision.drinkCount.ToString();
       // food2.text = finishCollision.foodCount.ToString();
       // //score                                                      
    }
}
