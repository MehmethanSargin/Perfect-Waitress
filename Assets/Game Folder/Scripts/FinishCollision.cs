using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class FinishCollision : MonoBehaviour
{
    private ServingFoods servingFoods;
    private Move move;
    private CreateList createList;
    private SwerveMovement swerveMovement;
    int foodCount = 0;
    int drinkCount = 0;
    public GameObject tepsi1;
    public GameObject tepsi2;
    private AnimationController animationController;
    public bool isServing = false;
    public static event Action<GameObject> updateText;
    public static event Action finishCheck;
    public static event Action<string> triggerAnim;

   

    private void Start()
    {
        swerveMovement = FindObjectOfType<SwerveMovement>();
        servingFoods = FindObjectOfType<ServingFoods>();
        move = FindObjectOfType<Move>();
        createList = FindObjectOfType<CreateList>();
        animationController = GetComponent<AnimationController>();
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            swerveMovement.enabled = false;
            move.speed = 0;
            servingFoods.DoTweenMethod(createList.foods);
            finishCheck?.Invoke();
            animationController.ServeTrigger();
            isServing = true;
            Invoke("TepsiActive",2.5f);
        }
        else if (other.CompareTag("Food"))
        {
            gameObject.GetComponent<PlayerStack>().StackLeftSide(other.gameObject);
            //foodCount++;
            updateText?.Invoke(other.gameObject);
        }
        else if (other.CompareTag("Foodd"))
        {
            gameObject.GetComponent<PlayerStack>().StackLeftSide(other.gameObject);
            //foodCount++;
            updateText?.Invoke(other.gameObject);
        }
        else if (other.CompareTag("Drink"))
        {
            gameObject.GetComponent<PlayerStack>().StackRightSide(other.gameObject);
            //drinkCount++;
            updateText?.Invoke(other.gameObject);
        }
    }

    private void TepsiActive()
    {
        tepsi1.SetActive(false);
        tepsi2.SetActive(false);
    }
    
}
