using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy"){
            animator.SetBool("isAttacking",true);
    
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        animator.SetBool("isAttacking", false);
    }
}
