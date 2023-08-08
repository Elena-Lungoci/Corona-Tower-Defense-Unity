using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator animator;

    int lungs_path;
    int alveoli_path;

    void Start(){

        // setting random path for lungs and alveoli
        alveoli_path = Random.Range(1,7);
        lungs_path = Random.Range(1,7);
        animator.SetInteger("lungs_path", lungs_path);
    }
    

    public void GoToAlveoliAnimation(){
        //animator.SetBool("finishedLungsPath", true);
        animator.SetInteger("alveoli_path", alveoli_path);
    }

    public void ReachedTheEnd(){ //when reaching the end of alveoli
        // increase humidity
        //remove from alveoli enemies list

        Destroy(gameObject);
    }

   
}
