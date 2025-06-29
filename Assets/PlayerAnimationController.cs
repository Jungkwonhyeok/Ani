using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // ĳ���Ϳ� �ִ� Animator ������Ʈ�� ������
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // ����Ű �Է°� �ޱ�
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // ����Ű�� ������ ������ �߻� = Speed > 0.1
        bool isMoving = (horizontal != 0 || vertical != 0);

        // Speed �Ķ���� ���� (0 �Ǵ� 1, �Ǵ� �ε巴�� �ϰ� ������ 0 ~ 1 ���̷�)
        animator.SetFloat("Speed", isMoving ? 1f : 0f);
    }
}
