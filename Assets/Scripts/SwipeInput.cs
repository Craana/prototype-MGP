using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{
    [SerializeField] private Vector2 fingerDown;
    [SerializeField] private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;
    private bool fingerUsed = false;
    public float SWIPE_THRESHOLD = 20f;
    [SerializeField] CharacterMovingScript CMS;

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        {
        
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }
            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }
            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
                fingerUsed = true;
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
           
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
            
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }


   public void OnSwipeUp()
    {
        Debug.Log("Swipe UP");
        fingerUsed = false;
        CMS.isJumping = true;
    }

    void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
        fingerUsed = false;
        CMS.isSliding = true;
    }

    void OnSwipeLeft()
    {

        //this function calls from camera area to manipulate level object
        Debug.Log("Swipe Left");
        fingerUsed = false;
    }

    void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
        fingerUsed = false;
    }

}