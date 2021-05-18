using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ServingFoods : MonoBehaviour
{
    PlayerStack foodList;

    [SerializeField]
    private Transform food;

    [SerializeField]
    private Transform food1;

    [SerializeField]
    private Transform drink;

    [Range(0.05f, 10.0f), SerializeField]
    private float moveDuration = 1.0f;

    [SerializeField]
    private Ease moveEase = Ease.Linear;
    
    private void Start()
    {
        foodList = FindObjectOfType<PlayerStack>();
    }

    public void DoTweenMethod(List<GameObject> foods1)
    {

        StartCoroutine(pause(foodList.collectableObject));
    }

    public IEnumerator pause(List<GameObject> foods1)
    {
        
        for (int i = 0; i < foods1.Count; i++)
        {
            if (foods1[i].CompareTag("Food"))
            {
              Vector3 targetPosition = new Vector3(food.position.x, food.position.y, food.position.z);
              foods1[i].transform.DOMove(targetPosition, moveDuration).SetEase(moveEase);
              yield return new WaitForSeconds(0.3f);
            }
            else if (foods1[i].CompareTag("Foodd"))
            {
                Vector3 targetPosition = new Vector3(food1.position.x, food1.position.y, food1.position.z);
                foods1[i].transform.DOMove(targetPosition, moveDuration).SetEase(moveEase);
                yield return new WaitForSeconds(0.3f);
            }
            else if (foods1[i].CompareTag("Drink"))
            {
                Vector3 targetPosition = new Vector3(drink.position.x, drink.position.y, drink.position.z);
                foods1[i].transform.DOMove(targetPosition, moveDuration).SetEase(moveEase);
                yield return new WaitForSeconds(0.3f);
            }
            
            
        }

        /*for (int i = 4; i < foods1.Count; i++)
        {
            Vector3 targetPosition = new Vector3(food.position.x-1, food.position.y, food.position.z);
            foods1[i].transform.DOMove(targetPosition, moveDuration).SetEase(moveEase);
            yield return new WaitForSeconds(0.15f);
        }*/

    }

}
