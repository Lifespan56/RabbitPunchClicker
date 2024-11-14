using TMPro;
using UnityEngine;

public class UI_MoneyBoard : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    int Money = 0;

    private void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        GameManager.Instance.UI_MoneyBoard = this;
    }

    private void Start()
    {
        textMeshPro.text = Money.ToString();
    }

    public void MoneyUpdate(int addScore)//호출없음
    {
        Money += addScore;
        textMeshPro.text = Money.ToString();
    }
}
