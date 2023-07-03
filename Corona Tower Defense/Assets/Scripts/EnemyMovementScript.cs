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
        alveoli_path = Random.Range(1,7);
        Debug.Log(alveoli_path);
        lungs_path = Random.Range(1,7);
        animator.SetInteger("lungs_path", lungs_path);
    }
    

    public void GoToAlveoliAnimation(){
        //animator.SetBool("finishedLungsPath", true);
        animator.SetInteger("alveoli_path", alveoli_path);
    }

    public void ReachedTheEnd(){
        // increase humidity

        Destroy(gameObject);
    }

   
}
