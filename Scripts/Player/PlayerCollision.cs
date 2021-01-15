using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

[HideInInspector] Rigidbody rb;


    void Awake() {
        rb = GetComponent<Rigidbody>();    
    }
    void OnCollisionEnter(Collision other) {
        Debug.Log("Collision");
        if(other.transform.tag != "playersGround"){
            rb.freezeRotation = false;
            StartCoroutine(MyCoroutine());
        }     
    }

    IEnumerator MyCoroutine(){
        yield return new WaitForSecondsRealtime(3f);
        gameObject.SetActive(false);
        GamePlayManager.instance.inAir = false;
        GamePlayManager.instance.alivePlayersCount--;
        GamePlayManager.instance.nextPlayerToShoot();
    }
}
