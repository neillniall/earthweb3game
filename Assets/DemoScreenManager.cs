using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoScreenManager : MonoBehaviour
{
    public GameObject dashboard;
    public GameObject wallet;
    public GameObject nftScreen;

    // Start is called before the first frame update
    void Start()
    {
        dashboard.SetActive(true);
        wallet.SetActive(false);
        nftScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableWallet()
    {
        dashboard.SetActive(false);
        wallet.SetActive(true);
        nftScreen.SetActive(false);
    }

    public void EnableDashboard()
    {
        dashboard.SetActive(true);
        wallet.SetActive(false);
        nftScreen.SetActive(false);
    }

    public void EnableNFTScreen()
    {
        dashboard.SetActive(false);
        wallet.SetActive(false);
        nftScreen.SetActive(true);
    }

    public void LoadRaceScene()
    { 
        SceneManager.LoadScene(1);
    }
}
