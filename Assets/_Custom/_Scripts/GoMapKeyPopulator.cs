namespace EARTH {

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoMapKeyPopulator : MonoBehaviour
{
    public GoMap.GOMap map;

    // Start is called before the first frame update
    void Awake()
    {
        map.mapbox_accessToken = Singleton.Instance.EnvironmentVariableManager.GO_MAP_API_KEY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
