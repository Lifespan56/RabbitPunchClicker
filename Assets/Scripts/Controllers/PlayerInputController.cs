using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public event Action OnBasicAttack;
    private bool progress;

    //마우스 누름>모션>모션동안 재입력 통제>애니메이션클립>점수가산>실제스코어 및 UI갱신
    public void OnInput_LeftClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnBasicAttack?.Invoke();
        }
    }
}
