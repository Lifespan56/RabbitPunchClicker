using TMPro;
using UnityEngine;

public class UI_ScoreBoard : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    int score = 0;

    private void Awake()
    {
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        GameManager.Instance.UI_ScoreBoard = this;
    }

    private void Start()
    {
        textMeshPro.text = score.ToString();
    }

    public void ScoreUpdate(int addScore)//Calculator AddScore(int)에서 호출
    {
        score += addScore;
        textMeshPro.text = score.ToString();
    }

}
