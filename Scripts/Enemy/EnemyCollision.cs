using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCollision : MonoBehaviour
{

[SerializeField] public int points;
Rigidbody rb;
Animator anim;
   void Awake() {
       rb = GetComponent<Rigidbody>();
       anim = GetComponent<Animator>();
   }

   void Start() {
       GamePlayManager.instance.enemy += 1;
       GamePlayManager.instance.maxScore += points;
   }
   void OnCollisionEnter(Collision col){
        if (col.collider.tag == "Ground" || col.collider.tag == "Player" || rb.velocity.z > 0.5f){
           anim.SetBool("Died",true);
           StartCoroutine(MyCoroutine());
        }
    }

    IEnumerator MyCoroutine(){
        yield return new WaitForSecondsRealtime(1.5f);
        GamePlayManager.instance.score += points;
        GamePlayManager.instance.enemy -= 1;
        gameObject.SetActive(false);
        Destroy(this);
    }
}
