using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Dont destroy keeps music from being destroyed between scenes
public class DontDestroy : MonoBehaviour
{
  private GameObject[] _music; //array of gameobjs
  private void Awake()
  {

    DontDestroyOnLoad(this.gameObject); //Dont destroy music upon loading new scenes
  }
  private void Update()
  {
    _music = GameObject.FindGameObjectsWithTag("Music"); //find all music objs and fill _music with them
    
    if (_music.Length > 1) { Destroy(_music[1]); } //if more than one music player exists delete the additional one
  }
}
