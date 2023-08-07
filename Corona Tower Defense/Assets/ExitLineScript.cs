using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLineScript : MonoBehaviour
{
    // Start is called before the first frame update
   
    public Enemy_tracker enemyTracker;

    void Start()
    {
       
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        enemyTracker.alveoli_enemies.Remove(other.gameObject);
    }
}
