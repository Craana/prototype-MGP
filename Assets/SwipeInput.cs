using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeInput : MonoBehaviour
{

    public Vector2 startPos;
    public Vector2 direction;
    public bool directionChosen;

    void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            if (direction.y > 0)
            {
                Debug.Log("Jump?");
                Reset();
            }
            else if (direction.y < 0)
            {
                Debug.Log("Slide?");
                Reset();
            }
            else if (direction.x < 0)
            {
                Debug.Log("Do something?");
                Reset();
            }
            else
            {
                Debug.Log("You what?");
                Reset();
            }
        
        }
    
        void Reset()
        {
            startPos.Set(0,0);
            direction.Set(0,0);
            directionChosen = false;
        }
    
    }
}