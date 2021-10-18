using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
  public Image DeathImage;
  public float playerHealth = 100f;
  
    // Start is called before the first frame update
   public void TakePlayerDamage(float dmg)
  {
    playerHealth -= dmg;
    
  }
  private void Start()
  {
    DeathImage.gameObject.SetActive(false);
  }
  private void Update()
  {
    if(playerHealth <= 0)
    {
      Die();
    }
  }
  void Die() 
  {
    Cursor.lockState = CursorLockMode.Confined;
    Cursor.visible = true;
    DeathImage.gameObject.SetActive(true);
    Animator anim = this.GetComponent<Animator>();
    anim.Play("Death");
    
  }
    
}
