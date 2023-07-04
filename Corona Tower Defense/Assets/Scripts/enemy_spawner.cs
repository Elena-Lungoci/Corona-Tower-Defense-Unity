using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;

    public float spawn_rate = 2;

    public float timer = 0;
    void Start()
    {
        spawn_enemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawn_rate){
            timer += Time.deltaTime;
        }
        else{
            timer = 0;
            spawn_enemy();

        }
    }

    void spawn_enemy(){
         Instantiate(enemy, this.transform);
    }
}
