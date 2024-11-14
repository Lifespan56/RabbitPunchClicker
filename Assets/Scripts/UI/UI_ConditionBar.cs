using UnityEngine;
using UnityEngine.UI;

public class UI_ConditionBar : MonoBehaviour
{
    private PlayerStatHandler playerStatHandler;
    private Image StaminaBar;
    int score = 0;
    int curStamina;
    int curStamina_Max;
    private void Awake()
    {
        StaminaBar = transform.Find("Bar_Stamina").GetComponent<Image>();
        GameManager.Instance.UI_ConditionBar = this;
        playerStatHandler = GameManager.Instance.Player.statHandler;
    }

    private void Start()
    {
        curStamina_Max = playerStatHandler.curStamina_Max;
        curStamina = playerStatHandler.curStamina;
    }

    private void Update()
    {
        BarUpdate();
    }

    public void BarUpdate()
    {
        StaminaBar.fillAmount = curStamina / curStamina_Max;
    }
}
