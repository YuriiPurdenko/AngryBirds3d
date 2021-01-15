using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool isPressed = false;
    [SerializeField] Rigidbody rb;
    [SerializeField] public bool isAlive = true;
     
    [SerializeField] GameObject shootRb;
    
    void FixedUpdate() {
         if(isPressed){
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                    if(hit.point.z < 4.9f){
                         rb.position = hit.point;
                    }    
            }
        }   
    }

    void OnMouseDown() {
        isPressed = true;
        if(!GamePlayManager.instance.inAir){
            rb.isKinematic = true;
        }
    }

    void OnMouseUp() {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot(){
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpringJoint>().spring = 0;
        this.enabled = false; 
        GamePlayManager.instance.inAir = true;
        
    }
}