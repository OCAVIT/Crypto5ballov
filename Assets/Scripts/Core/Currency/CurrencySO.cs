using UnityEngine;

[CreateAssetMenu(menuName = "CryptoExchange/Currency", fileName = "CurrencySO")]
public class CurrencySO : ScriptableObject
{
    [SerializeField] private string currencyName;
    [SerializeField] private float minPrice;
    [SerializeField] private float maxPrice;
    [SerializeField] private Sprite icon;
    [Range(0f, 1f)]
    [SerializeField] private float volatility;
    [SerializeField] private float priceUpdateInterval;

    public string CurrencyName => currencyName;
    public float MinPrice => minPrice;
    public float MaxPrice => maxPrice;
    public Sprite Icon => icon;
    public float Volatility => volatility;
    public float PriceUpdateInterval => priceUpdateInterval;
}