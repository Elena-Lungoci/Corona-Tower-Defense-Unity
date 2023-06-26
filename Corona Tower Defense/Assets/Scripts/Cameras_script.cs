using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameras_script : MonoBehaviour
{
    public GameObject alveoliCamera;
    public GameObject lungsCamera;

    [ContextMenu("Go to alveoli screen")]

    public void goToAlveoliSreen(){
        alveoliCamera.SetActive(true);
        lungsCamera.SetActive(false);
    }

    [ContextMenu("go to lungs screen")]
    public void goToLungsScreen(){
        alveoliCamera.SetActive(false);
        lungsCamera.SetActive(true);
    }
}
