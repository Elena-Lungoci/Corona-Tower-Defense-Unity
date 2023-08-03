using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class attack : MonoBehaviour //macrophage attack
{
    // Start is called before the first frame update
    public Animator animator;

    
    bool is_attacking;

    public List<GameObject> attacked_enemies = new List<GameObject>();

    GameObject currentTarget;

    enemy_attack targetScript;

    float test_timer;

    HealthBar health_bar_script;

    Tower_script towerScript;


    void Start()
    {
        towerScript = this.GetComponent<Tower_script>();
        is_attacking = false;
        attacked_enemies.Clear();
        currentTarget = null;
        test_timer = 0;
        towerScript.current_hp = towerScript.hp;

        health_bar_script = this.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.GetComponentInParent<HealthBar>();
       
        health_bar_script.SetMaxHealth(towerScript.hp);
        
    }

    // Update is called once per frame
    void Update()
    {
            if(towerScript.current_hp <= 0){
                Die();
            }

            if(currentTarget != null){
                Attack(currentTarget);
                health_bar_script.SetHealth(towerScript.current_hp);
            }
            
            if (attacked_enemies.Count ==0 && is_attacking == true){
            animator.SetBool("isAttacking", false); 
            is_attacking = false;
        }
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Enemy"){
            animator.SetBool("isAttacking",true);
            is_attacking = true;
            attacked_enemies.Add(collision.gameObject);

            
            if (attacked_enemies.Count == 1){
                SetCurrentTarget();

            }
    
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (attacked_enemies.Count ==0){
            animator.SetBool("isAttacking", false); 
            is_attacking = false;
        }
        
        
        attacked_enemies.Remove(other.gameObject);

        if (attacked_enemies.Count != 0){
            SetCurrentTarget();
        }
        
    }

    private void Die(){
        attacked_enemies.Clear();

        Destroy(gameObject);
    }

    private void Attack(GameObject target_enemy){
        targetScript.current_hp -= towerScript.dps * Time.deltaTime;

      
        
        
    }

    private void SetCurrentTarget(){
        currentTarget = attacked_enemies[0];
        targetScript = currentTarget.GetComponent<enemy_attack>();
    }
}
