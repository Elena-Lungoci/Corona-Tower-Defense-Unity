using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> towers; // list of tower prefabs

    public GameObject placingTiles;

    int selected_tower = -1; //number of the tower to be spawned; -1 = no selected tower
   

    public void SelectTower(int tower_number){
        selected_tower = tower_number;
        placingTiles.SetActive(true);
        Debug.Log(selected_tower);


    }

    public void DeselectTower(){    
        selected_tower = -1;
        placingTiles.SetActive(false);
        Debug.Log("tower deselected");

        // make it deselect when square not pressed
    }

    public void Spawn_Tower(Vector3 position){
        Instantiate(towers[selected_tower], position, Quaternion.identity);
        DeselectTower();

    }

    
}
