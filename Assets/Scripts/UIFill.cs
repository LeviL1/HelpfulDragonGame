using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIFill : MonoBehaviour
{
  public float maxValue;
  public Image fill;
  private PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
    health = FindObjectOfType<PlayerHealth>();

    maxValue = health.playerHealth;

    fill.fillAmount = 1;

    }

    // Update is called once per frame
    void Update()
    {
    fill.fillAmount = health.playerHealth / maxValue;
    }
  
}
