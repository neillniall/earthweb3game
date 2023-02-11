using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnvironmentVariableManager : MonoBehaviour
{
    public GoMap.GOMap[] maps;
    public string GO_MAP_API_KEY;

    // Start is called before the first frame update
    void Awake()
    {
        //activate enemies
        foreach (GoMap.GOMap map in maps)
        {
            map.mapbox_accessToken = GO_MAP_API_KEY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
