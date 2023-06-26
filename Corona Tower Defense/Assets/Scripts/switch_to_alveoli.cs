using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_to_alveoli : MonoBehaviour
{
    // Start is called before the first frame update
    public Cameras_script camerasScript;

    void Start(){
        camerasScript = GameObject.FindGameObjectWithTag("cameras").GetComponent<Cameras_script>();
    }
    private void OnMouseDown() {

        camerasScript.goToAlveoliSreen();
        
    }

    
}
