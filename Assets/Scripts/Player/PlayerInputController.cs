using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public event Action OnBasicAttack;
    public bool IsProgress;
    public bool IsToggle;

    public bool IsTired = false;//UI_ConditionBar.cs에서 공격> 스테미너 소모시 통제

    //행동중일때 클릭을 무효화 하고싶다
    //클릭>통제조건true>통제조건false로 돌려야 하는데 어느시점에서 돌려야 하는가
    //캐릭터 스텟 힘,민첩에 따라 애니메이션 속도가 변동된다
    //강의처럼 Invoke("함수명",공격쿨타임)을 하기 어렵다
    //그렇다고 애니메이션끝에 클립을 일일이 달기에는 애니메이션 추가시 대응이 어려울것이다
    //사실 지금도 공격 애니메이션 중간에 클립이 있지만..
    //모든 공격 후 Ready로 돌아가니 Ready시작에 클립

    public void OnInput_LeftClick(InputAction.CallbackContext context)
    {
        if (IsTired) { return; }

        if (context.phase == InputActionPhase.Started && !IsProgress && !IsToggle)
        {
            IsProgress = true;
            OnBasicAttack?.Invoke();
            //PlayerAnimContorller.cs Anim_Attack()
        }
        //IsProgress = false로 돌리는 시점
        //Ready시작 클립
    }

    public void OnInput_TabToggle(InputAction.CallbackContext context)
    {
        if(!IsToggle)
        {
            GameManager.Instance.UI_ShopMenu.gameObject.SetActive(true);
            IsToggle = true;
        }
        else if(IsToggle)
        {
            GameManager.Instance.UI_ShopMenu.gameObject.SetActive(false);
            IsToggle = false;
        }
    }
}
