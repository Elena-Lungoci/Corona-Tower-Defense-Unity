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
    Tower_script targetScript;

    HealthBar health_bar_script;

    public Enemy_tracker enemyTracker;
    

    void Start()
    {
        current_hp = hp;
        target = null;

        health_bar_script = this.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.GetComponentInParent<HealthBar>();

        health_bar_script.SetMaxHealth(hp);
        enemyTracker = GameObject.FindGameObjectWithTag("alveoli_terrain").GetComponent<Enemy_tracker>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (current_hp <= 0){
            
            target = null;
            enemyTracker.alveoli_enemies.Remove(this.gameObject); //if one day enemies can die in lungs screen, check if in lungs or not
            Destroy(gameObject);
        }
        health_bar_script.SetHealth(current_hp); //maybe not the best design

        if (target != null){
            Attack();

        }


    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("WBC")){
            previous_speed = animator.speed;
            animator.speed = 0;
            target = other.gameObject;
            int tower_layer = other.gameObject.layer;

            targetScript = target.GetComponent<Tower_script>(); //this is macrophage attack and here it becomes a problem
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
