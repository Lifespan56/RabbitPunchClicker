using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _Instance;

    public static PlayerManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
            }
            return _Instance;
        }

    }

    private void Awake()
    {
        if (_Instance == null)
        {
            gameObject.name = "PlayerManager";
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
}

