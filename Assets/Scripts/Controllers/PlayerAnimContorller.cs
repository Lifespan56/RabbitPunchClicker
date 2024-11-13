using UnityEngine;

public class PlayerAnimContorller : MonoBehaviour
{
    private Animator animator;
    private Enums.BasicAttackType atkType;
    public Calculator calculator;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        calculator = PlayerManager.Instance.Player.calculator;
    }

    private void Start()
    {
        PlayerManager.Instance.Player.controller.OnBasicAttack += Anim_Attack;
        //전투태세 전환 다른곳에서 해야함
        animator.SetBool("IsFight", true);
        //스탯변동시 업데이트 되어야함
        animator.SetFloat("AttackSpeed", 1f);
    }

    private void Anim_Attack()
    {
        if(calculator.GetForAnim_Critical())//크리인가 부터 판정
        {
            animator.SetTrigger("IsCritical");
        }
        else//크리가 아니면 공격4종중 하나
        {
            animator.SetInteger("AttackType", calculator.GetForAnim_Normal());
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
