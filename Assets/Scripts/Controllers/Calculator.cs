using UnityEngine;
using Random = UnityEngine.Random;

public class Calculator : MonoBehaviour
{
    public PlayerStatHandler playerStatHandler;

    private int atkTypeCount;
    private int beforeInt;
    private void Awake()
    {
        playerStatHandler = PlayerManager.Instance.Player.statHandler;
    }
    private void Start()
    {
        atkTypeCount = (int)Enums.BasicAttackType.Count;
    }
    public int GetNormalForAnim()//PlayerAnimContorller.cs에서 호출
    {
        int rand;

        do//일반 공격4종 이전 공격모션과 같으면 다시돌려 매번 다른 모션을 보여준다
        {
            rand = Random.Range(0, atkTypeCount);
        }
        while (beforeInt == rand);
        beforeInt = rand;
        return rand;
    }

    public bool GetCriticalForAnim()//PlayerAnimContorller.cs에서 호출
    {
        int rand;
        rand = Random.Range(0, 101);
        //단순히 백분율 0~100으로 랜덤하게 나온 숫자가 현재 크리티컬확률 범위내라면
        return playerStatHandler.curCriticalChance >= rand;
    }
}
