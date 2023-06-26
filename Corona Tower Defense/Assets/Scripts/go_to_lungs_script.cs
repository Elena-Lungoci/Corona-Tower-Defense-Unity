using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_to_lungs_script : MonoBehaviour
{
    // Start is called before the first frame update
    public Cameras_script camerasScript;

    void Start(){
        camerasScript = GameObject.FindGameObjectWithTag("cameras").GetComponent<Cameras_script>();
    }
    private void OnMouseDown() {

        camerasScript.goToLungsScreen();
        
    }
}
