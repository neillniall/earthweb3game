using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSingletonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Singleton.Instance.Web3Manager.chain == null)
        {
            Debug.Log("Need to setup Web3Manager values");
        } else
        {
            Debug.Log("Web3Manager values are set");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
