using System;
using System.Collections.Generic;
using UnityEngine;

public class WalletManager : MonoBehaviour
{
    public static WalletManager Instance { get; private set; }

    public event Action<float> OnBalanceChanged;
    public event Action<string, int> OnCurrencyAmountChanged;

    [SerializeField] private WalletConfigSO walletConfig;

    private float balance;
    private readonly Dictionary<string, int> currencyAmounts = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        balance = walletConfig.InitialBalance;
        currencyAmounts["Kroken"] = 0;
        currencyAmounts["Dobner"] = 0;
        currencyAmounts["Ukhta"] = 0;
    }

    public float Balance => balance;

    public int GetCurrencyAmount(string currencyName)
    {
        return currencyAmounts.TryGetValue(currencyName, out var amount) ? amount : 0;
    }

    public bool CanBuy(string currencyName, float price)
    {
        return balance >= price;
    }

    public bool CanSell(string currencyName)
    {
        return GetCurrencyAmount(currencyName) > 0;
    }

    public bool Buy(string currencyName, float price)
    {
        if (!CanBuy(currencyName, price)) return false;
        balance -= price;
        currencyAmounts[currencyName]++;
        OnBalanceChanged?.Invoke(balance);
        OnCurrencyAmountChanged?.Invoke(currencyName, currencyAmounts[currencyName]);
        return true;
    }

    public bool Sell(string currencyName, float price)
    {
        if (!CanSell(currencyName)) return false;
        balance += price;
        currencyAmounts[currencyName]--;
        OnBalanceChanged?.Invoke(balance);
        OnCurrencyAmountChanged?.Invoke(currencyName, currencyAmounts[currencyName]);
        return true;
    }
}