using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
  public float health = 100;
  private Animator anim;
  public float pointAmount = 100;
  private ScoreKeep score;
  private void Start()
  {
    score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreKeep>();
    anim = this.GetComponent<Animator>();
  }
  private void FixedUpdate()
  {
    if (health <= 0) { Die(); }
  }
  public void FireBreath(float dmg) 
  {
    anim.Play("Dizzy");
    health -= dmg;
    
  }
  public void Die() 
  {
    
    anim.Play("Die");
    health = 1f;
    Destroy(this.gameObject, 2f);
    score.AddPoints(pointAmount);


  }
}
