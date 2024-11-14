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

    public void ScoreUpdate(int addScore)//Calculator AddScore(int)에서 호출
    {
        Money += addScore;
        textMeshPro.text = Money.ToString();
    }
}
