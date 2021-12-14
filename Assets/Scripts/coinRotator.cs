using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinRotator : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] scoreCounter scorecounter;

    private void Start()
    {
        
    }


    void FixedUpdate()
    {
        transform.Rotate(0, rotateSpeed , 0);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            scorecounter.AddScore();
            Destroy(this.gameObject);
        }
    }
    
}
