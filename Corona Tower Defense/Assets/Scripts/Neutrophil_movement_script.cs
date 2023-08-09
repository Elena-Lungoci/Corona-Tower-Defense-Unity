using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrophil_movement_script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public Enemy_tracker enemyTracker;
    public Animator animator;

    public Tower_script towerScript;

    public float speed;


    //enemy distance
    float enemy_x_position;
    float enemy_y_position;
    float neutrophil_x_position;
    float neutrophil_y_position;
    float distance;
    float minDistance;
    float target_x_position;
    float target_y_position;
    float y_position_difference;
    float x_position_difference;


    float originalScale;

    enemy_attack targetScript;
    HealthBar health_bar_script;




    


    
    void Start()
    {
        target = null;

        towerScript = this.transform.GetChild (1).gameObject.GetComponent<Tower_script>();
        towerScript.current_hp = towerScript.hp;
        health_bar_script = this.transform.GetChild (0).gameObject.transform.GetChild (0).gameObject.GetComponentInParent<HealthBar>();
        health_bar_script.SetMaxHealth(towerScript.hp);

        enemyTracker = GameObject.FindGameObjectWithTag("alveoli_terrain").GetComponent<Enemy_tracker>();

    }

    // Update is called once per frame
    void Update()
    {
        health_bar_script.SetHealth(towerScript.current_hp);
        if (towerScript.current_hp <= 0){
            Destroy(gameObject);
        }
        // target setting
        if(target  == null){
            minDistance = 0; 
            if(enemyTracker.alveoli_enemies.Count == 0){
                //patrol
            }
            else{
                //sets the target to be closest enemy 
                UpdateCurrentPosition();

                

                foreach(GameObject enemy in enemyTracker.alveoli_enemies){
                    if(enemy == null){
                        //do nothing
                    }

                    else{
                        enemy_x_position = enemy.transform.position.x;
                        enemy_y_position = enemy.transform.position.y;
                    

                        distance = DetermineDistance(enemy_x_position, enemy_y_position, neutrophil_x_position, neutrophil_y_position);
                        if (minDistance == 0 || distance < minDistance){
                            minDistance = distance;
                            target = enemy;
                            
                        }
                    }
                    
                    
                    

                }
                targetScript = target.GetComponent<enemy_attack>();



                
                




            }
        }
        else{
            UpdateCurrentPosition();
            UpdateTargetPosition();

            y_position_difference = Mathf.Abs(neutrophil_y_position - target_y_position);

            if(neutrophil_y_position < target_y_position && y_position_difference>= 0.1){
                //move up
                MoveUp();
                
                
            }
            else if (neutrophil_y_position > target_y_position && y_position_difference>= 0.1){
                //move down
                MoveDown();
            }


            else{ //if its already on same line
                //move left or right or attack
                x_position_difference = Mathf.Abs(neutrophil_x_position-target_x_position);
                if(neutrophil_x_position < target_x_position && x_position_difference>= 0.1){
                    //move right
                    MoveRight();
                    
                    
                }
                else if (neutrophil_x_position > target_x_position && x_position_difference>= 0.1){
                    //move left
                    MoveLeft();
                }
                else{
                    //attack
                    Attack();
                }
               

            }
            
        }
    }
    

    void Attack(){
        targetScript.current_hp -= towerScript.dps * Time.deltaTime;
        animator.SetInteger("xSpeed", 0);
        animator.SetInteger("ySpeed", 0);
        animator.SetBool("isAttacking", true);
        
    }
    
    float DetermineDistance(float xPosition1, float yPosition1, float xPosition2, float yPosition2){
        float x_distance;
        float y_distance;
        float d;

        x_distance = Mathf.Abs(xPosition1-xPosition2);
        y_distance = Mathf.Abs(yPosition1 - yPosition2);


        d = Mathf.Sqrt(Mathf.Pow(x_distance, 2f) + Mathf.Pow(y_distance, 2f));

        return d;


        
        
    }
    void UpdateCurrentPosition(){
        neutrophil_x_position = this.transform.position.x;
        neutrophil_y_position = this.transform.position.y;
    } 
    void UpdateTargetPosition(){
        target_x_position = target.transform.position.x;
        target_y_position = target.transform.position.y;
    }

    void MoveLeft(){
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        animator.SetInteger("xSpeed", -1);
        animator.SetInteger("ySpeed", 0);
        animator.SetBool("isAttacking", false);
       
        
    }
    void MoveRight(){
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        animator.SetInteger("xSpeed", 1);
        animator.SetInteger("ySpeed", 0);
        animator.SetBool("isAttacking", false);
        
    }
    void MoveUp(){
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        animator.SetInteger("xSpeed", 0);
        animator.SetInteger("ySpeed", 1);
        animator.SetBool("isAttacking", false);
        
    }
    void MoveDown(){
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        animator.SetInteger("xSpeed", 0);
        animator.SetInteger("ySpeed", -1);
        animator.SetBool("isAttacking", false);
        
    }

  
}
