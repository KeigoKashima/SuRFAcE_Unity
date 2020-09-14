using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Instantiate : MonoBehaviour
{
    public GameObject prefab;
    int num_robots = 900;
    int line = 30;
    // Start is called before the first frame update
    void Start()
    {
      int num = num_robots;
      Vector3 position;
      for(int i = 1; i < num+1; i++){
        if(i == 1){
          position = new Vector3((i-1)%line,0,(i-1)/line);
        }else{
          position = new Vector3((i-1)%line,0,(i-1)/line);
        }
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        go.name = Convert.ToString(i);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
