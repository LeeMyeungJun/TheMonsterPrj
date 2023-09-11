using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm; //카메라 이동관리

    Animator m_animator;
    private Rigidbody m_rigidBody;

    private bool m_wasGrounded;
    private bool m_isGrounded;
    //private List<Collider> m_collisions = new List<Collider>();

    public float m_moveSpeed = 2.0f;
    public float m_jumpForce = 5.0f;
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;

    
    //private bool RollEnd = true;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = characterBody.GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        //마우스잠그기
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        LookAround();
        Move();
        JumpingAndLanding();
        Rolling();
        Attacking();

        m_wasGrounded = m_isGrounded;
    }

    //임시
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;

    float _targetRotation = 0.0f;
    float _rotationVelocity;
    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool isMove = moveInput.magnitude != 0;
        m_animator.SetBool("isMove", isMove);

        if (isMove)
        {
            //Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            //Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            //Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;


            /* LMJ 수정코드 .. */
            //여기회전
            _targetRotation = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg +
                                Camera.main.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            //회전 여기까지

            //전진
            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
            transform.position += targetDirection * (Time.deltaTime * 3f);
            m_isGrounded = true;


            /* ..  ..     .. */
            //m_animator.SetBool("isRoll", false);

            //characterBody.forward = moveDir;
            //transform.position += moveDir * (Time.deltaTime * 5f); //5f가뭔지모르겠음. speed 인가
            //m_isGrounded = true;
        }
        //Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z)normalized, Color.red);
    }


    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;
        if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            //m_animator.SetBool("Grounded", false);
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            //m_animator.SetBool("Grounded", true);
            m_animator.SetTrigger("Land");
        }

        if (!m_isGrounded && m_wasGrounded)
        {
            //m_animator.SetBool("Grounded", true);
            m_animator.SetTrigger("Jump");
        }

    }

    private void Rolling()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_animator.SetBool("isRoll", true);
        }
        else
        {
            m_animator.SetBool("isRoll", false);
        }
    }

    private void Attacking()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_animator.SetBool("isAttack", true);
        }
        else
        {
            m_animator.SetBool("isAttack", false);
        }
    }

    private void Running()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_animator.SetBool("isRun", true);
        }
        else
        {
            m_animator.SetBool("isRun", false);
        }
    }

    private void LookAround()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 351f);
        }
        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x, camAngle.z);
    }

}