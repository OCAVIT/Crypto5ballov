using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [Header("UI Prefabs")]
    [SerializeField] private Transform buySellPanel;
    [SerializeField] private Transform ratesPanel;
    [SerializeField] private CurrencyBuySellView buySellPrefab;
    [SerializeField] private CurrencyView ratePrefab;

    [Header("SO")]
    [SerializeField] private List<CurrencySO> currencies;

    private readonly List<CurrencyAggregator> aggregators = new();

    private void Awake()
    {
        if (currencies == null || currencies.Count == 0)
        {
            currencies = new List<CurrencySO>(Resources.LoadAll<CurrencySO>("CurrencySO"));
        }

        foreach (var currency in currencies)
        {
            var aggregatorGO = new GameObject($"{currency.CurrencyName}Aggregator");
            var aggregator = aggregatorGO.AddComponent<CurrencyAggregator>();
            aggregator.Init(currency);
            aggregators.Add(aggregator);

            var buySellView = Instantiate(buySellPrefab, buySellPanel);
            buySellView.Init(aggregator);

            var rateView = Instantiate(ratePrefab, ratesPanel);
            rateView.Init(aggregator);
        }
    }
}