using UnityEngine;

public class PlayerAnimContorller : MonoBehaviour
{
    public Animator animator;
    private Calculator calculator;
    private PlayerInputController playerInputController;//bool변수하나 돌리려고 참조하는게 맞나..

    private Enums.BasicAttackType atkType;

    private int multiply;

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        calculator = GameManager.Instance.Player.calculator;
        playerInputController = GameManager.Instance.Player.controller;
        GameManager.Instance.Player.controller.OnBasicAttack += Anim_Attack;
        //전투태세 전환 다른곳에서 해야함
        animator.SetBool("IsFight", true);
    }

    private void Anim_Attack()
    {
        if (calculator.GetForAnim_Critical())//크리인가 부터 판정
        { 
            animator.SetTrigger("IsCritical");
            multiply = 3;
        }
        else//크리가 아니면 공격4종중 하나
        {
            animator.SetInteger("AttackType", calculator.GetForAnim_Normal());
            animator.SetTrigger("IsNormal");
            multiply = 1;
        }
    }

    public void Anim_AttackSpeed(float speed)//StatHandler에서 호출
    {
        animator.SetFloat("AttackSpeed", speed);
    }

    public void Animclip_FistContact()//이 함수는 애니메이션 클립에서 호출 multiply는 Anim_Attack()에서 결정된다 
    {
        calculator.AddScore(multiply);
    }

    public void Animclip_StartReady()//Ready가 시작될때 클립에서 호출된다 입력 통제를 품
    {
        playerInputController.IsProgress = false;
    }
}
