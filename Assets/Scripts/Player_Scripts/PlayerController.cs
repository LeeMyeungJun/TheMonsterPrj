using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    //public TrailRenderer trail;


    [SerializeField]
    private Transform characterBody;
    [SerializeField]
    private Transform cameraArm; //카메라 이동관리
    [SerializeField]
    private TrailRenderer trail;

    Animator m_animator;
    private Rigidbody m_rigidBody;

    private bool isMove = true;
    private bool isGrounded;

    //private List<Collider> m_collisions = new List<Collider>();

    public float m_moveSpeed = 2.0f;
    public float m_jumpForce = 5.0f;
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 1.0f;

    private float rotationSpeed = 3.0f;
    public float groundCheckLine = 1.03f;

    Vector3 velocity = Vector3.zero;
    void Start()
    {
        m_animator = characterBody.GetComponent<Animator>();
        m_rigidBody = GetComponent<Rigidbody>();
        //마우스잠그기
        Cursor.lockState = CursorLockMode.Locked;
        trail.GetComponent<TrailRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        //LookAround();
        JumpingAndLanding();
        Move();
        Rolling();
        Attacking();
    }

    //임시
    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;

    float _targetRotation = 0.0f;
    float _rotationVelocity;
    private void Move()
    {
        if (!isMove)
            return;        

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        bool InputCheck = moveInput.magnitude != 0;
        
        if (InputCheck)
        {
            //Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            //Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            //Vector3 moveDir = lookForward * moveInput.y + lookRight * moveInput.x;


            /* LMJ 수정코드 .. */
            //여기회전+ Camera.main.transform.eulerAngles.y
            _targetRotation = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            //회전 여기까지

            //전진
            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;
            velocity = targetDirection * (Time.deltaTime * rotationSpeed);
            
            transform.position += velocity;

            m_animator.SetFloat("MoveSpeed", velocity.magnitude * 100);
            
            

            //Debug.Log(vel.magnitude * 100);
            /* ..  ..     .. */
            //m_animator.SetBool("isRoll", false);

            //characterBody.forward = moveDir;
            //transform.position += moveDir * (Time.deltaTime * 5f); //5f가뭔지모르겠음. speed 인가
            //m_isGrounded = true;
        }
        else
        {
            velocity = Vector3.zero;
            m_animator.SetFloat("MoveSpeed",0);
        }
        //Debug.DrawRay(cameraArm.position, new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z)normalized, Color.red);
    }

    private void JumpingAndLanding()
    {
        //bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;
        //if (jumpCooldownOver && m_isGrounded && Input.GetKey(KeyCode.Space))
        //{
        //    m_jumpTimeStamp = Time.time;
        //    m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
        //    //m_animator.SetBool("Grounded", false);
        //}

        Debug.DrawRay(m_rigidBody.position + Vector3.up, Vector3.down * groundCheckLine, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(m_rigidBody.position + Vector3.up, Vector3.down, out hit, groundCheckLine))
        {
            if (hit.collider.name == "Terrain")
            {
                isGrounded = true;
            }
        }

        m_jumpTimeStamp += Time.deltaTime;
        bool jumpCooldownOver = m_jumpTimeStamp >= m_minJumpInterval;
        if (jumpCooldownOver && isGrounded && Input.GetKey(KeyCode.Space))
        {
            m_jumpTimeStamp = 0;
            isGrounded = false;
            m_rigidBody.AddForce(m_jumpForce * (velocity.normalized + Vector3.up).normalized, ForceMode.Impulse);
        }

        m_animator.SetBool("Grounded", isGrounded);
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
    
    IEnumerator FadeOut()
    {
        Color c = trail.material.color;
        for (int i =10; i>=0; i--)
        {
            float f = i / 10.0f;
            c.a = f;
            trail.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
        
    }

    private void velocityRoll()
    {
        m_rigidBody.AddForce(transform.forward*10, ForceMode.Impulse);
    }

    private void OnisMove()
    {
        isMove = true;
    }
    private void OffisMove()
    {
        isMove = false;
    }
    private void OnFlash()
    {
        trail.enabled = true;
    }
    private void OffFlash()
    {
        StartCoroutine(FadeOut());
        //trail.enabled = false;
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