using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neutrophil_movement_script : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public Enemy_tracker enemyTracker;


    //enemy distance
    float enemy_x_position;
    float enemy_y_position;
    float neutrophil_x_position;
    float neutrophil_y_position;
    float distance;
    float minDistance;

    
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(target  == null){
            distance = 0; //reset distance and target value when enemy dies
            if(enemyTracker.alveoli_enemies.Count == 0){
                //patrol
            }
            else{
                //sets the target to be closest enemy
                neutrophil_x_position = Mathf.Abs(this.transform.position.x);
                neutrophil_y_position = Mathf.Abs(this.transform.position.y);

                

                foreach(GameObject enemy in enemyTracker.alveoli_enemies){
                    enemy_x_position = Mathf.Abs(enemy.transform.position.x);
                    enemy_y_position = Mathf.Abs(enemy.transform.position.y);
                   

                    distance = DetermineDistance(enemy_x_position, enemy_y_position, neutrophil_x_position, neutrophil_y_position);
                    if (minDistance == 0 || distance < minDistance){
                        minDistance = distance;
                        target = enemy;
                        Debug.Log("target set");
                    }
                    
                    

                }



                
                




            }
        }
        else{
            //follows target
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
}
