using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConnectWalletManager : MonoBehaviour
{ 
    public GameObject connectButton;
    public GameObject disconnectButton;
    public Web3ContractManager contractManager;

    /*
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Coroutine_you_want_to_run", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Coroutine_you_want_to_run()
    {
        Debug.Log("Coroutine_you_want_to_run");
        if (contractManager.IsWalletConnected().Result)
        {
            connectButton.SetActive(false);
            disconnectButton.SetActive(true);
        }
        else
        {
            connectButton.SetActive(true);
            disconnectButton.SetActive(false);
        }

        yield return new WaitForSeconds(10);
     
        StartCoroutine(Coroutine_you_want_to_run());
    }*/
}
