using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // 캐릭터에 있는 Animator 컴포넌트를 가져옴
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 방향키 입력값 받기
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 방향키를 누르면 움직임 발생 = Speed > 0.1
        bool isMoving = (horizontal != 0 || vertical != 0);

        // Speed 파라미터 설정 (0 또는 1, 또는 부드럽게 하고 싶으면 0 ~ 1 사이로)
        animator.SetFloat("Speed", isMoving ? 1f : 0f);
    }
}
