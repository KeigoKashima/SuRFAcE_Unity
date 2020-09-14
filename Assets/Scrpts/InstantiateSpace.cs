using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpace : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      if(Input.GetKeyDown(KeyCode.Space)){
        for (int i=1;i<10;i++){
          Vector3 position = new Vector3(1+25*Random.value,10,1+25*Random.value);
          Instantiate(prefab, position, Quaternion.identity);
        }

      }

    }
}
