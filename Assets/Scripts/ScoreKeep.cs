using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreKeep : MonoBehaviour
{
  public float Score = 0f;
  public Text scoretxt;
    // Start is called before the first frame update
    void Start()
    {
    scoretxt.text = Score.ToString();
    }
  private void FixedUpdate()
  {
    scoretxt.text = Score.ToString();
  }

  public void AddPoints(float points) 
  {
    Score += points;
  }
}
