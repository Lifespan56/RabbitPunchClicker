using UnityEngine;
using UnityEngine.UI;

public class UI_ConditionBar : MonoBehaviour
{
    private PlayerStatHandler playerStatHandler;
    private PlayerInputController playerInputController;

    private Image StaminaBar;
    private int score = 0;
    private float curStamina;
    private float curStamina_Max;
    private void Awake()
    {
        StaminaBar = transform.Find("Bar_Stamina").GetComponent<Image>();
        GameManager.Instance.UI_ConditionBar = this;
        playerStatHandler = GameManager.Instance.Player.statHandler;
        playerInputController = GameManager.Instance.Player.GetComponent<PlayerInputController>();
    }

    private void Start()
    {
        GameManager.Instance.Player.GetComponent<PlayerInputController>().OnBasicAttack += ConsumStamina;
    }

    private void Update()
    {
        BarUpdate();
    }

    public void ConsumStamina()
    {
        playerStatHandler.curStamina -= 10f;
    }

    public void BarUpdate()
    {
        StaminaBar.fillAmount = playerStatHandler.curStamina / playerStatHandler.curStamina_Max;

        if(playerStatHandler.curStamina <= 10f) { playerInputController.IsTired = true; }
        else { playerInputController.IsTired = false; }
    }
}
