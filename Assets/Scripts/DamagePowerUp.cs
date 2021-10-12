using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DamagePowerUp : MonoBehaviour
{
  public GameObject postProcess;
  public Material mat;
  private Color color;
  private void Start()
  {
    color = mat.color;
    mat.color = new Color(200, 52, 159, 255);
    
    
  }
  private void OnTriggerEnter(Collider other)
  {
    
    {
      if (other.CompareTag("Player"))
    {
        Collider col = this.gameObject.GetComponent<Collider>();
        col.enabled = false;
        mat.color = color;
        
         
        StartCoroutine(DoubleDamageRoutine());
        
      }
    }
  }

  IEnumerator DoubleDamageRoutine() 
  {
    Shooting dmg = FindObjectOfType<Shooting>();
    dmg.dmg *= 2;
    postProcess.SetActive(true);
    yield return new WaitForSeconds(2f);
    postProcess.SetActive(false);
    dmg.dmg /= 2f; 
  }
}
