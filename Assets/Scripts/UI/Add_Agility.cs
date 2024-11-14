using UnityEngine;
using UnityEngine.UI;

public class Add_Agility : MonoBehaviour, ISale
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
        btn.onClick.AddListener(SaleItem);//인자가 없을때
        //btn.onClick.AddListener(() => Method(i));인자가 있을때
    }
    public void SaleItem()
    {
        //UI_MoneyBoard.Money -=
        GameManager.Instance.Player.statHandler.Stat_Agility(1);
    }
}
