using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Target : MonoBehaviour
{
  
  private NavMeshAgent agent;
  private GameObject player;
  public ParticleSystem particle;
  public float damage = 15;
  private float nextAttackTime = 0f;
  public float attackRate = 1;
  private Animator anim;

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    anim = this.GetComponent<Animator>();
    agent = GetComponent<NavMeshAgent>();
  }
  
  void Update()
    {
   
    agent.SetDestination(player.transform.position);
    if (agent.remainingDistance <= 7 && Time.time > nextAttackTime)
    {
      nextAttackTime = Time.time + attackRate;
      StartCoroutine(AttackRoutine());
    }
    else 
    {
      StopCoroutine(AttackRoutine());
      
    }
  }

 
  IEnumerator AttackRoutine()
  {
    
        yield return new WaitForSeconds(3f);
        Physics.SphereCast(particle.transform.position, 3f, particle.transform.forward, out RaycastHit hitInfo);
    if (agent.remainingDistance <= 7) { StopCoroutine(AttackRoutine()); }
    anim.Play("Attack01");
    particle.Play();
    if (hitInfo.collider.tag == "Player" && hitInfo.collider != null) 
        {
            PlayerHealth health = hitInfo.collider.GetComponent<PlayerHealth>();
            health.TakePlayerDamage(30);
        }
        else { StopCoroutine(AttackRoutine()); }
    
      
    
  }
   

}
