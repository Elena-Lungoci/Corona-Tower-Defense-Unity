using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_tower : MonoBehaviour
{
    // Start is called before the first frame update
    public tower_spawner tower_spawner_script;
    void Start()
    {
        tower_spawner_script = GameObject.FindGameObjectWithTag("Logic").GetComponent<tower_spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
        tower_spawner_script.Spawn_Tower(this.transform.position);

        //make it unable to spawn a second tower on the same square
    }
}
