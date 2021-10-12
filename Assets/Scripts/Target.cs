using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Target : MonoBehaviour
{
  public float health = 50f;
  private NavMeshAgent agent;
  public GameObject player;
    public ParticleSystem particle;
  public float damage = 15;
  private float nextAttackTime = 0f;
  public float attackRate = 1;
  // Start is called before the first frame update

  private void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }
  // Update is called once per frame
  void Update()
    {
        if(health <= 0)
    {
      Destroy(this.gameObject);
    }
    agent.SetDestination(player.transform.position);
    if (agent.remainingDistance <= 7 && Time.time > nextAttackTime)
    {
      nextAttackTime = Time.time + attackRate;
      StartCoroutine(AttackRoutine());
    }
        else { StopCoroutine(AttackRoutine()); }
  }
  
  public void TakeDamage(float dmg)
  {
    health -= dmg;
  }
  IEnumerator AttackRoutine()
  {
    
        yield return new WaitForSeconds(3f);
        Physics.SphereCast(transform.position, 5f, transform.forward, out RaycastHit hitInfo); 
        if(agent.remainingDistance <= 7) { StopCoroutine(AttackRoutine()); }
        particle.Play();
        if (hitInfo.collider.tag == "Player") 
        {
            PlayerHealth health = hitInfo.collider.GetComponent<PlayerHealth>();
            health.TakePlayerDamage(30);
        }
        else { StopCoroutine(AttackRoutine()); }
    
      
    
  }
   

}
