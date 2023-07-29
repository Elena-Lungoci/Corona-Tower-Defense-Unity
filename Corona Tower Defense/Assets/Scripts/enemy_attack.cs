using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    float previous_speed;

    public float hp = 10;

    public float current_hp;

    public float dps;

    GameObject target;
    attack targetScript;

    HealthBar health_bar_script;
    

    void Start()
    {
        current_hp = hp;
        target = null;

        health_bar_script = this.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.GetComponentInParent<HealthBar>();

        health_bar_script.SetMaxHealth(hp);
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hp <= 0){
            
            target = null;
            Destroy(gameObject);
        }

        if (target != null){
            Attack();
            health_bar_script.SetHealth(current_hp); //this will be a problem against ranged attacks
        }


    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("WBC")){
            previous_speed = animator.speed;
            animator.speed = 0;
            target = other.gameObject;
            targetScript = target.GetComponent<attack>();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("WBC")){

            animator.speed = previous_speed;
        }
    }

    private void Attack(){
        targetScript.current_hp -= dps * Time.deltaTime;
    }

}
