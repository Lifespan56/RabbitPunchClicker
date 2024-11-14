using UnityEngine;

public class UI_ShopMenu : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.UI_ShopMenu = this;
        gameObject.SetActive(false);
    }
}
