using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public float hp = 10;

    public float dps = 2;

    public float current_hp =10;

    bool is_attacking;

    public List<GameObject> attacked_enemies = new List<GameObject>();

    GameObject currentTarget;

    enemy_attack targetScript;


    void Start()
    {
        is_attacking = false;
        attacked_enemies.Clear();
        currentTarget = null;
       

        
    }

    // Update is called once per frame
    void Update()
    {
            if(current_hp <= 0){
                Die();
            }

            if(currentTarget != null){
                Attack(currentTarget);
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

        SetCurrentTarget();
    }

    private void Die(){
        attacked_enemies.Clear();

        Destroy(gameObject);
    }

    private void Attack(GameObject target_enemy){
        targetScript.current_hp -= dps * Time.deltaTime;

        Debug.Log(targetScript.current_hp);
        
        
    }

    private void SetCurrentTarget(){
        currentTarget = attacked_enemies[0];
        targetScript = currentTarget.GetComponent<enemy_attack>();
    }
}
