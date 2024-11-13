using System.Collections;
using UnityEngine;

public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStatSO statSO;
    [SerializeField] private int curHealth_Max;
    [SerializeField] private int curHealth;
    [SerializeField] private float curHealth_Recovery_Time;
    [SerializeField] private int curHealth_Recovery_PerTime;

    [SerializeField] private int curStamina_Max;
    [SerializeField] private int curStamina;
    [SerializeField] private int curStamina_Consum_PerAttack;
    [SerializeField] private float curStamina_Recovery_Time;
    [SerializeField] private int curStamina_Recovery_PerTime;

    [SerializeField] private int curStrength;
    [SerializeField] private int curAgility;
    [SerializeField] public int curCriticalChance { get; private set; }

    private void Awake()
    {

    }

    private void Start()
    {
        Init();
    }
    //입력 > 스텟기반 판정> 애니컨트롤러
    private void Init()
    {
        curHealth_Max = statSO.health_Max;
        curHealth = curHealth_Max;
        curHealth_Recovery_Time = statSO.health_Recovery_Time;
        curHealth_Recovery_PerTime = statSO.health_Recovery_PerTime;

        curStamina_Max = statSO.stamina_Max;
        curStamina = curStamina_Max;
        curStamina_Consum_PerAttack = statSO.stamina_Consum_PerAttack;
        curStamina_Recovery_Time = statSO.stamina_Recovery_Time;
        curStamina_Recovery_PerTime = statSO.stamina_Recovery_PerTime;

        curStrength = statSO.strength;
        curAgility = statSO.agility;
        curCriticalChance = statSO.criticalChance;

        //힘, 민첩은 공격속도에 계수로 작용한다 민첩이 더 많이 작용된다
        //힘이 오르는데 왜 빨라지냐는 의문이 있는가?
        //팔굽혀펴기를 예로 들면 근육이 많은 사람이 마른 사람보다 빠르다
        //근력이 민첩함의 기반이 되는 것이다

        StartCoroutine("StaminaRecovery");
    }

    IEnumerator StaminaRecovery()
    {
        while (true)
        {
            yield return new WaitForSeconds(curStamina_Recovery_Time);
            curStamina = Mathf.Max(curStamina += curStamina_Recovery_PerTime, curStamina_Max);
        }
    }

    //스탯변동시 갱신
    public float GetForAnim_AttackSpeed()
    {
        return (1f + (float)curStrength / 100 + (float)curAgility / 50);
    }
    


}
