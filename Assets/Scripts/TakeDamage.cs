using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
  public float health = 100;
  private Animator anim;
  private void Start()
  {
    anim = this.GetComponent<Animator>();
  }
  private void Update()
  {
    if (health <= 0) { Die(); }
  }
  public void FireBreath() 
  {
    anim.Play("Dizzy");
    health -= 20;
    
  }
  public void Die() 
  {
    anim.Play("Die");
    Destroy(this.gameObject, 2f);
  }
}
