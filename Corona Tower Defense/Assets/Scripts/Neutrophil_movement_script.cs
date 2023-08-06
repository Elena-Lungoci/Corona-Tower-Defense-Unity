using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrophil_movement_script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public Enemy_tracker enemyTracker;
    public Animator animator;
    public Rigidbody2D rb;

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


    Vector3 velocity;
    


    
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {

        velocity = rb.velocity;
        



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
                    enemy_x_position = enemy.transform.position.x;
                    enemy_y_position = enemy.transform.position.y;
                   

                    distance = DetermineDistance(enemy_x_position, enemy_y_position, neutrophil_x_position, neutrophil_y_position);
                    if (minDistance == 0 || distance < minDistance){
                        minDistance = distance;
                        target = enemy;
                    }
                    
                    

                }



                
                




            }
        }
        else{
            UpdateCurrentPosition();
            UpdateTargetPosition();

            y_position_difference = Mathf.Abs(neutrophil_y_position - target_y_position);

            if(neutrophil_y_position < target_y_position && y_position_difference>= 0.1){
                //move up
                transform.Translate(Vector3.up * Time.deltaTime * speed);
                



                
            }
            else if (neutrophil_y_position > target_y_position && y_position_difference>= 0.1){
                //move down
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            else{
                //move left or right
                Debug.Log("On the same line");
            }
            
        }
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
}
