using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blademove : MonoBehaviour
{
//this comment is just to commit
    Vector3 initPos;
   
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = new Vector3(33, Mathf.Sin(Time.time) + initPos.y, 6);
       //transform.position = new Vector3(Mathf.Sin(Time.time) + initPos.x, 10 , 5);

    }
}
