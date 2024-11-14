using UnityEngine;
using UnityEngine.UI;

public class UI_ShopMenu : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.UI_ShopMenu = this;
        gameObject.SetActive(false);
    }
}

public class ShopBtnConnect : MonoBehaviour
{
    Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();
    }

    private void Start()
    {
        //씬에 프리팹을 동적생성하니 버튼에 드래그&드롭한게 다 끊긴다
        //버튼의 이벤트도 동적으로 연결해야한다
        //btn.onClick.AddListener(Method);인자가 없을때
        //인자가 있을때
        btn.onClick.AddListener(() => Purchase(1));
    }

    public void Purchase(int i)
    {

    }
}