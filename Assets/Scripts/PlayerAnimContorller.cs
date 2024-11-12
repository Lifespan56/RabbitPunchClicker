using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAnimContorller : MonoBehaviour
{
    private Animator animator;
    private PlayerInputController playerController;
    private BasicAttackType atkType;

    private int atkTypeCount;

    int beforeInt;
    private void Awake()
    {
        animator = transform.Find("Sprite_Main").GetComponent<Animator>();
        playerController = gameObject.GetComponent<PlayerInputController>();
    }

    private void Start()
    {
        playerController.OnBasicAttack += Anim_BasicAttack;
        animator.SetBool("IsFight", true);

        atkTypeCount = (int)BasicAttackType.Count;
    }

    private void Anim_BasicAttack()
    {
        int rand;

        do
        {
            rand = Random.Range(0, atkTypeCount);
        }
        while (beforeInt == rand);
       
        animator.SetInteger("AttackType", rand);
        beforeInt = rand;
    }
}
