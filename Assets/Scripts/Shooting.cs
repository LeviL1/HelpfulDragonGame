using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
  public TakeDamage enemy;
  public float dmg;
  public float fireRate;
  
  public ParticleSystem system;
  public GameObject impactEffect;
  private float nextTimeToFire = 0f;
  public Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
    {
      nextTimeToFire = Time.time + 1f / fireRate;
      Shoot(dmg);
    }
    }
  void Shoot(float damage)
  {
    
    system.Play();
    RaycastHit hit;
    if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Mathf.Infinity))
    {
      Debug.Log(hit.transform.name);
      if (hit.transform.CompareTag("Enemy"))
        {
        enemy = hit.transform.GetComponent<TakeDamage>();
        enemy.FireBreath(dmg);
      }
    }
  }
  
}
