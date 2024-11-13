﻿using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInputController controller;
    public PlayerStatHandler statHandler;
    public PlayerAnimContorller animContorller;
    public Calculator calculator;

    private void Awake()
    {
        PlayerManager.Instance.Player = this;
        controller = gameObject.GetComponent<PlayerInputController>();
        statHandler = gameObject.GetComponent<PlayerStatHandler>();
        animContorller = GameObject.Find("Sprite_Main").GetComponent<PlayerAnimContorller>();
        calculator = gameObject.GetComponent<Calculator>();
    }
    private void Start()
    {
        controller.enabled = true;
        statHandler.enabled = true;
        animContorller.enabled = true;
        calculator.enabled = true;
    }
}

