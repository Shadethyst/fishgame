using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class DamageOnCollision : MonoBehaviour
{

    public UnityEvent OnDamageTaken;
    public UnityEvent onScore;
    public UnityEvent onItem;
    
    public Scorepoints pm;
    public PickScrewdriver psd;
    public PlayerHealth ph;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
     When an object collides with the enemy with this script, it checks if the colliding object is the player,
    if it is it invokes the OnDamageTaken event, which calls a function,
    currently use case is to call takeDamage in the PlayerHealth script to deal damage to the player
    and also can be used to call PlayerController to add knockback for example
     */

    void OnTriggerEnter2D(Collider2D other)
    {    
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided!");
            OnDamageTaken.Invoke();

            other.gameObject.GetComponent<PlayerController>().Rebound((Vector2)transform.position);
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Pearl"))
        {   
            Debug.Log("Player picked a pearl!");
            onScore.Invoke();
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Screwdriver"))
        {   
            Debug.Log("Player picked a screwdriver!");
            onItem.Invoke();
            gameObject.SetActive(false);
        }
    }
}
