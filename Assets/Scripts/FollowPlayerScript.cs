using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowPlayerScript : MonoBehaviour
{
    
    private Transform player; //player transform
    private NavMeshAgent nav; //nav mesh of the enemy
    // Start is called before the first frame update
    void Start()
    { //get nav mesh and player transfrom
        nav = this.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    { //move to the player position on update
       nav.destination = player.transform.position;
    }
}
