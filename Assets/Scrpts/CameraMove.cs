﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.UpArrow)){
        transform.position = new Vector3(this.transform.position.x,this.transform.position.y+0.1f,this.transform.position.z);
      }
      if(Input.GetKey(KeyCode.DownArrow)){
        transform.position = new Vector3(this.transform.position.x,this.transform.position.y-0.1f,this.transform.position.z);
      }
      if(Input.GetKey(KeyCode.RightArrow)){
        transform.position = new Vector3(this.transform.position.x+0.1f,this.transform.position.y,this.transform.position.z);
      }
      if(Input.GetKey(KeyCode.LeftArrow)){
        transform.position = new Vector3(this.transform.position.x-0.1f,this.transform.position.y,this.transform.position.z);
      }

    }
}
