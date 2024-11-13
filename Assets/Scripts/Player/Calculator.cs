using UnityEngine;
using Random = UnityEngine.Random;

public class Calculator : MonoBehaviour
{
    //전처리가 필요한 함수의 계산을 여기서 해볼까
    private PlayerStatHandler playerStatHandler;
    private UI_ScoreBoard UI_scoreBoard;

    private int atkTypeCount;
    private int beforeInt;
    private void Awake()
    {
        playerStatHandler = GetComponent<PlayerStatHandler>();
        UI_scoreBoard = PlayerManager.Instance.UI_ScoreBoard;
    }
    private void Start()
    {
        atkTypeCount = (int)Enums.BasicAttackType.Count;
    }
    public bool GetForAnim_Critical()//PlayerAnimContorller.cs에서 호출
    {
        int rand;
        rand = Random.Range(0, 101);
        //단순히 백분율 0~100으로 랜덤하게 나온 숫자가 현재 크리티컬확률 범위내라면
        return playerStatHandler.curCriticalChance >= rand;
    }
    public int GetForAnim_Normal()//PlayerAnimContorller.cs에서 호출
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

    public void AddScore(int multiply)//PlayerAnimContorller.cs Anim_Attack()에서 호출
    {
        int amount = playerStatHandler.curStrength * multiply;
        UI_scoreBoard.ScoreUpdate(amount);
    }
    
}
