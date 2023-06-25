using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_move_script : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3[] coordinates_path1 = {};
    void Start()
    {
        Debug.Log(coordinates_path1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;
    }
}
