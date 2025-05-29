using UnityEngine;

[CreateAssetMenu(menuName = "CryptoExchange/WalletConfig", fileName = "WalletConfigSO")]
public class WalletConfigSO : ScriptableObject
{
    [SerializeField] private float initialBalance;
    public float InitialBalance => initialBalance;
}