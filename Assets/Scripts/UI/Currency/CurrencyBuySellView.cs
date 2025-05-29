using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencyBuySellView : CurrencyView
{
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private TMP_Text messageText;

    public override void Init(CurrencyAggregator aggregator)
    {
        base.Init(aggregator);
        buyButton.onClick.AddListener(OnBuyClicked);
        sellButton.onClick.AddListener(OnSellClicked);
    }

    private void OnBuyClicked()
    {
        var price = aggregator.CurrentPrice;
        var name = aggregator.CurrencySO.CurrencyName;
        if (!WalletManager.Instance.Buy(name, price))
        {
            messageText.text = "Невозможно совершить покупку, недостаточно средств";
        }
        else
        {
            messageText.text = "";
        }
    }

    private void OnSellClicked()
    {
        var price = aggregator.CurrentPrice;
        var name = aggregator.CurrencySO.CurrencyName;
        if (!WalletManager.Instance.Sell(name, price))
        {
            messageText.text = "Невозможно совершить продажу, недостаточно средств";
        }
        else
        {
            messageText.text = "";
        }
    }
}