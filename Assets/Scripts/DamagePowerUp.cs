using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DamagePowerUp : MonoBehaviour
{
  public GameObject postProcess;

  private Transform mushroomScale;
  private void Start()
  {

    


  }
  private void OnTriggerEnter(Collider other)
  {
    
    {
      if (other.CompareTag("Player"))
    {
        Collider col = this.gameObject.GetComponent<Collider>();
        col.enabled = false;
        
        
         
        StartCoroutine(DoubleDamageRoutine());
        
      }
    }
  }

  IEnumerator DoubleDamageRoutine() 
  {
    Shooting dmg = FindObjectOfType<Shooting>();
    dmg.dmg *= 2;
    postProcess.SetActive(true);
    yield return new WaitForSeconds(4f);
    postProcess.SetActive(false);

    
    dmg.dmg /= 2f;
    yield return new WaitForSeconds(1);
    this.gameObject.SetActive(false);
  }
}
