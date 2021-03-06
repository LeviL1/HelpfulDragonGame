using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampfireHeal : MonoBehaviour
{
  private PlayerHealth health;
  private bool inTrigger = false;
  
    // Start is called before the first frame update
    void Start()
    {
    health = FindObjectOfType<PlayerHealth>();
    }

  private void OnTriggerStay(Collider other)
  {
    if (other.CompareTag("Player")) 
    {
      inTrigger = true;
      StartCoroutine(healthCouroutine(inTrigger));
      inTrigger = false;
    }
  }
  private void OnTriggerExit(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      inTrigger = false;
      StopCoroutine(healthCouroutine(inTrigger));
    }
  }
  IEnumerator healthCouroutine(bool trigger) 
  {
    if (inTrigger == true)
    {
      if (health.playerHealth < 100)
      {
        health.playerHealth += 1;
      }
    }
    yield return new WaitForSeconds(1f);
    
  }
}
