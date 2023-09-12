using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//在UI中的玩家，不会死亡，并且不受时间限制移动
public class UIPlayerController : MonoBehaviour
{
    
    [SerializeReference] float speed;
    [SerializeReference] float turnSpeed;
    [SerializeReference] Transform body;
    [SerializeReference] PlayerMoveLimit moveLimit;

    public PlayerInput playerInput;  //获取当前玩家控制方式（键盘/手柄）

    //static变量方便其他脚本获取
    public static UIPlayerController instance;

    Vector2 moveInput;
    //设置两个旋转变量（顺逆时针）以防止锁死
    float turnInputLeft;
    float turnInputRight;

    private void Awake()
    {
        //最优先实例化，防止因脚本引用顺序导致的空指针异常
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //使用Time.unscaledDeltaTime使玩家移动不受限于暂停的时间
        Move();
        Turn();       
    }

    //每次重新setactive时重置位置
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
        //玩家根节点下子物体旋转,当未按按键时自动为全0
        body.Rotate(0, 0, turnInputLeft * turnSpeed * Time.unscaledDeltaTime);
        body.Rotate(0, 0, turnInputRight * turnSpeed * Time.unscaledDeltaTime);
    }

    #region InputSystem Functions
    public void GetMoveInput(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    //顺逆时针旋转输入
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
