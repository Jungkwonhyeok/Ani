using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVE : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public float dash = 5f;
    public float rotspeed = 3f;

    private Vector3 dir = Vector3.zero;

    private bool ground = false;
    public LayerMask layer;

 

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();

        CheckGround();

        if(Input.GetButtonDown("Jump")  && ground)
        {
            Vector3 jumpPower = Vector3.up  * jumpHeight;
            rigidbody.AddForce(jumpPower, ForceMode.VelocityChange);
        }

        if(Input.GetButtonDown("Dash"))
        {
            Vector3 dashPower = this.transform.forward * -Mathf.Log(1/rigidbody.drag) * dash;
            rigidbody.AddForce(dashPower, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        // 점프 중에 추가 중력 적용 (낙하 속도 향상)
        if (!ground && rigidbody.velocity.y < 0)
        {
            rigidbody.AddForce(Vector3.down * 30f);  // ← 값은 실험적으로 조정 (20~40 정도)
        }

        if(dir != Vector3.zero)
        {
            if(Mathf.Sign(transform.forward.x) != Mathf.Sign(dir.x) || Mathf.Sign(transform.forward.z) != Mathf.Sign(dir.z))
            {
                transform.Rotate(0, 1, 0);
            }
            transform.forward = Vector3.Lerp(transform.forward, dir, rotspeed * Time.deltaTime);
        }

        rigidbody.MovePosition(this.gameObject.transform.position + dir *speed * Time.deltaTime);
    }

    void CheckGround()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + (Vector3.up * 0.2f), Vector3.down, out hit, 0.4f, layer))
        {
            ground = true;
        }
        else
        {
            ground = false;
        }
    }

   
}
