using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadLvlSelect : MonoBehaviour
{

  
    public void LoadLVLs()
  {
    SceneManager.LoadScene("LVLSelect", LoadSceneMode.Additive);
    
    SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(2));
  }
  public void LoadLVL1()
  {

    SceneManager.LoadScene("Lvl1", LoadSceneMode.Single);
  }
  public void LoadLVL2()
  {
    SceneManager.LoadScene("LVL2", LoadSceneMode.Single);
  }
  public void LoadLVL3()
  {
    SceneManager.LoadScene("LVL3", LoadSceneMode.Single);
  }
  public void LoadMainMenu()
  {
    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    
  }
  public void Exit()
  {
    Application.Quit();
  }
}
