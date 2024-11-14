using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;

    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return _Instance;
        }

    }

    private void Awake()
    {
        if (_Instance == null)
        {
            gameObject.name = "GameManager";
            _Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private Player _Player;
    public Player Player
    { 
        get { return _Player;}
        set { _Player = value; }
    }


    private UI_ScoreBoard _UI_ScoreBoard;
    public UI_ScoreBoard UI_ScoreBoard
    {
        get { return _UI_ScoreBoard; }
        set { _UI_ScoreBoard = value; }
    }


    private UI_MoneyBoard _UI_MoneyBoard;
    public UI_MoneyBoard UI_MoneyBoard
    {
        get { return _UI_MoneyBoard; }
        set { _UI_MoneyBoard = value; }
    }


    private UI_ConditionBar _UI_ConditionBar;
    public UI_ConditionBar UI_ConditionBar
    {
        get { return _UI_ConditionBar; }
        set { _UI_ConditionBar = value; }
    }


    private UI_ShopMenu _UI_ShopMenu;
    public UI_ShopMenu UI_ShopMenu
    {
        get { return _UI_ShopMenu; }
        set { _UI_ShopMenu = value; }
    }
    
}

