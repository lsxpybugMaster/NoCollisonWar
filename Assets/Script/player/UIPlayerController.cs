using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//��UI�е���ң��������������Ҳ���ʱ�������ƶ�
public class UIPlayerController : MonoBehaviour
{
    
    [SerializeReference] float speed;
    [SerializeReference] float turnSpeed;
    [SerializeReference] Transform body;
    [SerializeReference] PlayerMoveLimit moveLimit;

    public PlayerInput playerInput;  //��ȡ��ǰ��ҿ��Ʒ�ʽ������/�ֱ���

    //static�������������ű���ȡ
    public static UIPlayerController instance;

    Vector2 moveInput;
    //����������ת������˳��ʱ�룩�Է�ֹ����
    float turnInputLeft;
    float turnInputRight;

    private void Awake()
    {
        //������ʵ��������ֹ��ű�����˳���µĿ�ָ���쳣
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //ʹ��Time.unscaledDeltaTimeʹ����ƶ�����������ͣ��ʱ��
        Move();
        Turn();       
    }

    //ÿ������setactiveʱ����λ��
    private void OnEnable()
    {
        Debug.Log("you pause!");
        transform.localPosition = Vector3.zero;
    }

    void Move()
    {
        transform.Translate(moveInput * speed * Time.unscaledDeltaTime);
        if (moveLimit)
        {
            transform.position = moveLimit.Limit(transform.position);
        }
    }

    void Turn()
    {
        //��Ҹ��ڵ�����������ת,��δ������ʱ�Զ�Ϊȫ0
        body.Rotate(0, 0, turnInputLeft * turnSpeed * Time.unscaledDeltaTime);
        body.Rotate(0, 0, turnInputRight * turnSpeed * Time.unscaledDeltaTime);
    }

    #region InputSystem Functions
    public void GetMoveInput(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    //˳��ʱ����ת����
    public void GetTurnRInput(InputAction.CallbackContext ctx)
    {
        turnInputRight = -ctx.ReadValue<float>();
    }

    public void GetTurnLInput(InputAction.CallbackContext ctx)
    {
        turnInputLeft = ctx.ReadValue<float>();
    }


    #endregion
}
