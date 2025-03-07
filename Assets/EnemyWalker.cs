﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float walkLeft,walkRight = 0.2f;
    public float walkDirection = 0.5f;
    //ตอนตาย
    public GameObject Explode;
    Vector3 walkAmount;
    
    void Update()
    {
        walkAmount.x = (walkDirection * walkSpeed) * Time.deltaTime;
        if(walkDirection > 0.0f && transform.position.x >= walkRight){
            walkDirection = -1.0f;
        }else if(walkDirection < 0.0f && transform.position.x <= walkLeft){
            walkDirection = 1.0f;
        }
        transform.Translate(walkAmount);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "weaponA"){
            Destroy(other.gameObject);
            StartCoroutine(secondDeath(0.2f));
        }
    }

    IEnumerator secondDeath(float sec){
        yield return new WaitForSeconds(sec);
        Instantiate(Explode,transform.position,transform.rotation);
        Destroy(this.gameObject);
    }
}
