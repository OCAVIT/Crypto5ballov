using UnityEngine;
using TMPro;

public class WalletBalanceView : MonoBehaviour
{
    [SerializeField] private TMP_Text balanceText;

    private void Start()
    {
        WalletManager.Instance.OnBalanceChanged += OnBalanceChanged;
        OnBalanceChanged(WalletManager.Instance.Balance);
    }

    private void OnDestroy()
    {
        if (WalletManager.Instance != null)
            WalletManager.Instance.OnBalanceChanged -= OnBalanceChanged;
    }

    private void OnBalanceChanged(float newBalance)
    {
        balanceText.text = $"счирши: {newBalance:F2}";
    }
}