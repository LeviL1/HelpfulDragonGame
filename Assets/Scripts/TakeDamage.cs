using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
  public float health = 100;

  public void FireBreath() 
  {
    health -= 20;
  }
}
