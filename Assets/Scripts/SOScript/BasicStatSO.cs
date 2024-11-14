using UnityEngine;

public class BasicStatSO : ScriptableObject
{
    //공용부 이것을 상속받은 클래스SO만 CreateAssetMenu를 가진다
    [Header("건강(리소스 만들 여유가 있으면 치고받을 것)")]
    public int health_Max;
    public float health_Recovery_Time;
    public int health_Recovery_PerTime;
    [Header("신체활동에 필요한 기력")]
    public int stamina_Max;
    public int stamina_Consum_PerAttack;
    public float stamina_Recovery_Time;
    public int stamina_Recovery_PerTime;
    [Header("전투 능력치")]
    public int strength;
    public int agility;
}
