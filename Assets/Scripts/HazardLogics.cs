using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardLogics : MonoBehaviour
{

   private void OnTriggerEnter(Collider other) {
	   if (other.gameObject.tag == "Player")
	   {
		 other.gameObject.GetComponent<LifeCounter>().decreaseLife();
		 Debug.Log("I work!");
	   }
   }
}
