using UnityEngine;

[RequireComponent(typeof(Web3Manager))]
public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    public Web3Manager Web3Manager { get; private set; }
    public EnvironmentVariableManager EnvironmentVariableManager { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        Web3Manager = GetComponentInChildren<Web3Manager>();
        EnvironmentVariableManager = GetComponentInChildren<EnvironmentVariableManager>();
    }
}