using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text amountText;

    protected CurrencyAggregator aggregator;
    protected string currencyName;

    public virtual void Init(CurrencyAggregator aggregator)
    {
        this.aggregator = aggregator;
        var so = aggregator.CurrencySO;
        currencyName = so.CurrencyName;
        iconImage.sprite = so.Icon;
        nameText.text = so.CurrencyName;
        priceText.text = aggregator.CurrentPrice.ToString("F2");
        if (amountText != null)
            amountText.text = WalletManager.Instance.GetCurrencyAmount(currencyName).ToString();

        aggregator.OnPriceChanged += OnPriceChanged;
        WalletManager.Instance.OnCurrencyAmountChanged += OnCurrencyAmountChanged;
    }

    protected virtual void OnDestroy()
    {
        if (aggregator != null)
            aggregator.OnPriceChanged -= OnPriceChanged;
        if (WalletManager.Instance != null)
            WalletManager.Instance.OnCurrencyAmountChanged -= OnCurrencyAmountChanged;
    }

    protected virtual void OnPriceChanged(float newPrice)
    {
        priceText.text = newPrice.ToString("F2");
    }

    protected virtual void OnCurrencyAmountChanged(string name, int amount)
    {
        if (name == currencyName && amountText != null)
            amountText.text = amount.ToString();
    }
}