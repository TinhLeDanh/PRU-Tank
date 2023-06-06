/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    void Start()
    {
        Vector3 start = new Vector3(canvas.transform.position.x, canvas.transform.position.Y-50,
            canvas.transform.position.Z);
        Vector3 end = new Vector3(canvas.transform.position.x, canvas.transform.position.Y,
            canvas.transform.position.Z);
        canvas.transform = Vector3.Lerp( start, end, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
**/