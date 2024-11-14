using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputController controller;
    public PlayerStatHandler statHandler;
    public PlayerAnimContorller animContorller;
    public Calculator calculator;

    private void Awake()
    {
        controller = gameObject.GetComponent<PlayerInputController>();
        statHandler = gameObject.GetComponent<PlayerStatHandler>();
        animContorller = GameObject.Find("Sprite_Main").GetComponent<PlayerAnimContorller>();
        calculator = gameObject.GetComponent<Calculator>();
        GameManager.Instance.Player = this;
    }

}

