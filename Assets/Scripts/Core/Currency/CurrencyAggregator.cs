using System;
using UnityEngine;
using System.Collections;

public class CurrencyAggregator : MonoBehaviour
{
    public event Action<float> OnPriceChanged;

    private CurrencySO currencySO;
    private float currentPrice;

    public float CurrentPrice => currentPrice;
    public CurrencySO CurrencySO => currencySO;

    public void Init(CurrencySO so)
    {
        currencySO = so;
        currentPrice = (so.MinPrice + so.MaxPrice) / 2f;
        OnPriceChanged?.Invoke(currentPrice);
        StartCoroutine(UpdatePriceRoutine());
    }

    private IEnumerator UpdatePriceRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(currencySO.PriceUpdateInterval);

            float targetPrice = UnityEngine.Random.Range(currencySO.MinPrice, currencySO.MaxPrice);
            float delta = targetPrice - currentPrice;
            float change = delta * currencySO.Volatility;
            currentPrice += change;
            currentPrice = Mathf.Clamp(currentPrice, currencySO.MinPrice, currencySO.MaxPrice);

            OnPriceChanged?.Invoke(currentPrice);
        }
    }
}