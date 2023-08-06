using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_tracker : MonoBehaviour
{
    public List<GameObject> alveoli_enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            alveoli_enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        alveoli_enemies.Remove(other.gameObject);
    }
}
