using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    [SerializeField] private GameObject orderPanel;
    [SerializeField] private GameObject swipePanel;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject completeCanvas;
    [SerializeField] private GameObject failCanvas;
    [SerializeField] private GameObject confetti;
    [SerializeField] private Transform confettiPosition;
    
    
    [SerializeField] private ParticleSystem cupcakeParticleSystem;
    [SerializeField] private ParticleSystem coffeParticleSystem;
    [SerializeField] private ParticleSystem hamburgerParticleSystem;
    [SerializeField] private ParticleSystem chipsParticleSystem;
    [SerializeField] private ParticleSystem colaParticleSystem;
    

    SwerveInputSystem ınputSystem;

    public Image CoffeFilled;
    public Image CupcakeFilled;
    public Image HamburgerFilled;
    public Image PatatoFilled;
    public Image DrinkFilled;

   public TMP_Text desireFoodText;
    public TMP_Text desireSecondFoodText;
    public TMP_Text desireCoffeText;

    public TMP_Text FoodText;
    public TMP_Text SecondFood;
    public TMP_Text drinkText;

    int desireFood = 4;
    int desireSecondFood = 3;
    int desireDrink = 4;
    
    public int collectedFood;
    public int collectedSecondFood;
    public int collectedDrink;


    private bool panelOff = false;
    public bool PanelOff { get { return panelOff; } }

    private FinishCollision finishCollision;
    private AnimationController animationController;
    
    private GameObject king;
    private bool actionStart;
    
    private void Start()
    {
        #region Class
        ınputSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<SwerveInputSystem>();
        #endregion

        finishCollision = GameObject.FindWithTag("Player").GetComponent<FinishCollision>();
        animationController = GameObject.FindWithTag("Player").GetComponent<AnimationController>();
        //desireFoodText.text =  desireFood.ToString();
        //desireSecondFoodText.text = desireSecondFood.ToString();
        //desireCoffeText.text =  desireDrink.ToString();
        king = GameObject.FindWithTag("King");
    }

    private void OnEnable()
    {
        FinishCollision.updateText += UpdateUI;
        FinishCollision.finishCheck += FinishCheck;
    }

    private void OnDisable()
    {
        FinishCollision.updateText -= UpdateUI;
        FinishCollision.finishCheck -= FinishCheck;
    }

    private void Update()
    {
        if (ınputSystem.SwipeOn == true && panelOff == true)
        {
            swipePanel.SetActive(false);
        }

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            CupcakeFilled.fillAmount = 0 + ((float)collectedFood / (float)desireFood);
            CoffeFilled.fillAmount = 0 + ((float)collectedDrink / (float)desireDrink);
            if (CoffeFilled.fillAmount == 1)
            {
                coffeParticleSystem.gameObject.SetActive(true);
            }   
            if (CupcakeFilled.fillAmount == 1)
            {
                cupcakeParticleSystem.gameObject.SetActive(true);

            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            HamburgerFilled.fillAmount = 0 + ((float)collectedFood / (float)desireFood);
            PatatoFilled.fillAmount = 0 + ((float)collectedSecondFood / (float)desireSecondFood);
            DrinkFilled.fillAmount = 0 + ((float)collectedDrink /(float) desireDrink);
            if (HamburgerFilled.fillAmount == 1)
            {
                hamburgerParticleSystem.gameObject.SetActive(true);
            }
            if (PatatoFilled.fillAmount == 1)
            {
                chipsParticleSystem.gameObject.SetActive(true);
            }
            if (DrinkFilled.fillAmount == 1)
            {
                colaParticleSystem.gameObject.SetActive(true);
            }
        }
    }

    public void ButtonMethod()
    {
        orderPanel.SetActive(false);
        panelOff = true;
        swipePanel.SetActive(true);
        gameplayPanel.SetActive(true);
    }


    void UpdateUI(GameObject other)
    {
        switch (other.tag)
        {
            case "Food":
                collectedFood++;
                //FoodText.text = collectedFood.ToString() + "/ " + desireFood;
                break;
            
            case "Foodd":
                collectedSecondFood++;
               // SecondFood.text = collectedSecondFood.ToString() + "/ " + desireSecondFood;
                break;

            case "Drink":
                collectedDrink++;
              //  drinkText.text =  collectedDrink.ToString() + "/ " + desireDrink;
                break;
        }
    }

    void FinishCheck()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (collectedFood >= desireFood && collectedDrink >= desireDrink&& collectedSecondFood >= desireSecondFood)
            {
                if (actionStart == false)
                {
                    StartCoroutine(animationController.Fun());
                    king.GetComponent<Animator>().SetTrigger("LevelPassed");
                    StartCoroutine(ConfettiWithDelay(2.5f));
                    StartCoroutine(CompletePanelWithDelay(5f));
                    actionStart = true;
                }
            }
            else
            {
                king.GetComponent<Animator>().SetTrigger("LevelFailed");
                StartCoroutine(ClosePanelWithDelay(2));
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (collectedFood >= desireFood && collectedDrink >= desireDrink)
            {
                if (actionStart == false)
                {
                    StartCoroutine(animationController.Fun());
                    king.GetComponent<Animator>().SetTrigger("LevelPassed");
                    StartCoroutine(ConfettiWithDelay(1.5f));
                    StartCoroutine(CompletePanelWithDelay(4f));
                    actionStart = true;
                }
                
            }
            else
            {
                king.GetComponent<Animator>().SetTrigger("LevelFailed");
                StartCoroutine(ClosePanelWithDelay(2));
            }

        }
        
    }

    IEnumerator CompletePanelWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        completeCanvas.SetActive(true);
    }

    IEnumerator ClosePanelWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        failCanvas.SetActive(true);
    }

    IEnumerator ConfettiWithDelay(float delay)
    {
        yield return new  WaitForSeconds(delay);
        Instantiate(confetti, confettiPosition);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

