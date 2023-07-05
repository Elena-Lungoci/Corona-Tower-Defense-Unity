using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_characters_script : MonoBehaviour
{
    // Start is called before the first frame update
    public static Place_characters_script main;
    bool macrophage_button_selected = false; 
    void Start()
    {
        main = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void macrophage_button_clicked(){
        macrophage_button_selected = true;
    }
}
