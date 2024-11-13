using UnityEngine;

public class PlayerAnimContorller : MonoBehaviour
{
    private Animator animator;
    private Enums.BasicAttackType atkType;
    public Calculator calculator;
    public PlayerInputController inputController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        calculator = PlayerManager.Instance.Player.calculator;
        inputController = PlayerManager.Instance.Player.controller;
    }

    private void Start()
    {
        inputController.OnBasicAttack += Anim_Attack;
        //전투태세 전환 다른곳에서 해야함
        animator.SetBool("IsFight", true);
    }

    private void Anim_Attack()
    {
        if(calculator.GetCriticalForAnim())//크리인가 부터 판정
        {
            animator.SetTrigger("IsCritical");
        }
        else//크리가 아니면 공격4종중 하나
        {
            animator.SetInteger("AttackType", calculator.GetNormalForAnim());
            animator.SetTrigger("IsInput");
        }  
    }

    public void Anim_AttackSpeed(float speed)//StatHandler에서 호출
    {
        animator.SetFloat("AttackSpeed", speed);
    }

    public void Animclip_FistContact()
    {
        //유형별 스코어추가
    }
}
