using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerStack : MonoBehaviour
{
    public Transform leftSide, RightSide;
    float currentHeightLeftSide;
    float currentHeightRightSide;
    [SerializeField] float heightOffset;
    /*[HideInInspector]*/
    public List<GameObject> collectableObject = new List<GameObject>();
    

    //public void StackFood(GameObject gameObject)
    //{
    //    int randomNumber = Random.Range(0, 2);
    //    switch (randomNumber)
    //    {
    //        case 0:
    //            StackLeftSide(gameObject);
    //            break;

    //        case 1:
    //            StackRightSide(gameObject);
    //            break;
    //    }
    //}

    public void StackLeftSide(GameObject gameObject)
    {
        gameObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
        gameObject.transform.position = leftSide.position + new Vector3(0, currentHeightLeftSide, 0);
        gameObject.transform.parent = leftSide.transform;
        currentHeightLeftSide+=heightOffset;
        collectableObject.Add(gameObject);
    }

    public void StackRightSide(GameObject gameObject)
    {
        gameObject.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f);
        gameObject.transform.position = RightSide.position + new Vector3(0, currentHeightRightSide, 0);
        gameObject.transform.parent = RightSide.transform;
        currentHeightRightSide+=heightOffset;
        collectableObject.Add(gameObject);
    }
}