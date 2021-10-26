using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovingScript : MonoBehaviour
{

    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, 0, speed * Time.deltaTime);
        transform.Translate(movement);
    }


      void TouchInputs()
    {




    }





}
