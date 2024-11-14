using System.Collections;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    private PlayerAnimContorller playerAnimController;

    [SerializeField] private PlayerStatSO statSO;
    //[SerializeField] private int curHealth_Max;
    //[SerializeField] private int curHealth;
    //[SerializeField] private float curHealth_Recovery_Time;
    //[SerializeField] private int curHealth_Recovery_PerTime;

    [field: SerializeField] public int curStamina_Max;
    [field: SerializeField] public int curStamina;
    [SerializeField] private int curStamina_Consum_PerAttack;
    [SerializeField] private float curStamina_Recovery_Time;
    [SerializeField] private int curStamina_Recovery_PerTime;


    [field: SerializeField] public int curStrength { get; private set; }
    [SerializeField] private int curAgility;
    [field: SerializeField] public float curCriticalChance { get; private set; }

    private void Start()
    {
        playerAnimController = GameManager.Instance.Player.animContorller;
        Init();
    }
    //입력 > 스텟기반 판정> 애니컨트롤러
    private void Init()
    {
        //curHealth_Max = statSO.health_Max;
        //curHealth = curHealth_Max;
        //curHealth_Recovery_Time = statSO.health_Recovery_Time;
        //curHealth_Recovery_PerTime = statSO.health_Recovery_PerTime;

        curStamina_Max = statSO.stamina_Max;
        curStamina = curStamina_Max;
        curStamina_Consum_PerAttack = statSO.stamina_Consum_PerAttack;
        curStamina_Recovery_Time = statSO.stamina_Recovery_Time;
        curStamina_Recovery_PerTime = statSO.stamina_Recovery_PerTime;

        curStrength = statSO.strength;
        curAgility = statSO.agility;

        Update_CriticalChance();
        ForAnim_AnimSpeed();
        StartCoroutine("StaminaRecovery");
    }

    IEnumerator StaminaRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(curStamina_Recovery_Time);
            curStamina = Mathf.Min(curStamina += curStamina_Recovery_PerTime, curStamina_Max);
        }
    }

    public void ForAnim_AnimSpeed()//시작시1회, 힘,민첩 변동시마다 호출된다
    {
        //힘, 민첩은 공격속도에 계수로 작용한다 민첩이 더 많이 작용된다
        //힘이 오르는데 왜 빨라지냐는 의문이 있는가?
        //팔굽혀펴기를 예로 들면 근육이 많은 사람이 마른 사람보다 빠르다
        //근력이 민첩함의 기반이 되는 것이다
        playerAnimController.animator.SetFloat("AnimSpeed", 1f + (float)curStrength / 100 + (float)curAgility / 50);
    }

    //스탯변동의 구현
    //현재 스텟은 이 스크립트다 다 관리한다
    //외부에서 상승, 하락 입력이 들어오면 전처리,출력을 하게 될 것인데
    //스텟 종류가 여러개라면 어떤 스텟을 올리고 내리는지의 판단을 어떻게 해야하는가
    //외부에서의 입력은 물약이든 장비아이템이든 어떤 스텟인지는 명확하다
    //그런데 여기서 처리할때는? 종류별로 함수를 만든다? 뭔가 짜치는데 일단은 구현우선

    //외부 입력 > 종류별 처리
    public void Stat_Stamina_Recovery_Time(float value)//버튼에 직접 연결중
    {
        //회복주기는 0.1f보다 빨라지지 않는다
        curStamina_Recovery_Time = Mathf.Max(curStamina_Recovery_Time += value, 0.1f);
        //회복주기는 5f보다 느려지지않는다
        if(curStamina_Recovery_Time > 5f)
        {
            curStamina_Recovery_Time=5f;
        }
    }
    public void Stat_Strength(int value)//버튼에 직접 연결중
    {
        //힘은 1보다 낮아지지 않는다 상한은 없다
        curStrength = Mathf.Max(curStrength += value , 1);
        ForAnim_AnimSpeed();
        Update_CriticalChance();
    }
    public void Stat_Agility(int value)//버튼에 직접 연결중
    {
        //민첩은 1보다 낮아지지 않는다 상한은 없다
        curAgility = Mathf.Max(curAgility += value , 1);
        ForAnim_AnimSpeed();
        Update_CriticalChance();
    }
    private void Update_CriticalChance()
    {
        //소수점을 몇개까지 표시할건지 옵션이 없으니 간접적으로 구현한다고 한다
        curCriticalChance = Mathf.Round((curStrength / 5f + curAgility / 2f) * 100f) * 0.01f;
    }

}
