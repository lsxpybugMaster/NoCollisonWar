using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    
    [Header("基础设置")]
    [SerializeReference] float speed;
    [SerializeReference] float turnSpeed;
    [SerializeReference] Transform body;

    [Header("扩展设置")]
    [SerializeReference] bool locationLimit;
    public int HP; 

    [Tooltip("圆形限制范围的半径")]
    [SerializeReference] float sphereDistance;

    [Tooltip("限制移动的脚本(可选)")]
    [SerializeReference] PlayerMoveLimit moveLimit;

    //static变量方便其他脚本获取
    public static Transform static_transform;
    public static PlayerController instance;

    Vector2 moveInput;
    //设置两个旋转变量（顺逆时针）以防止锁死
    float turnInputLeft;
    float turnInputRight;

    //获取受伤害后的执行函数，对于一血的情况直接忽略
    public UnityEvent damagedFuctions;

    public bool isPaused;

    //用于跳关，自动推断
    int levelNumber;

    //调试模式不会死
    public bool DEBUG;

    private void Awake()
    {      
        //最优先实例化，防止因脚本引用顺序导致的空指针异常
        static_transform = transform;
        instance = this;
        isPaused = false;
        levelNumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    { 
        Move();
        Turn();    
        //有些关卡需设定玩家移动范围
        if(locationLimit)
        {
            locLimit();
        }
        //有些关卡玩家有多条命
        if(HP == 0)
        {
            HP = 1;
        }
        static_transform = transform;
    }


    void Move()
    {   
         transform.Translate(moveInput * speed * Time.deltaTime);
         if(moveLimit)
         {
            transform.position = moveLimit.Limit(transform.position);
         }
    }

    void Turn()
    {
        //玩家根节点下子物体旋转,当未按按键时自动为全0
        body.Rotate(0, 0, turnInputLeft * turnSpeed * Time.deltaTime);
        body.Rotate(0, 0, turnInputRight * turnSpeed * Time.deltaTime);
    }

    void locLimit()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) > sphereDistance)
            damaged();
    }

  

    public void damaged()
    {
        #region 调试输出
        if (DEBUG)
        {
            print("____GAMEOVER____!");
            return;
        }
        #endregion

        HP--;

        //死亡重开
        if (HP <= 0)
        {
            die();
        }
        //受伤相关
        else
        {
            damagedFuctions.Invoke();  //包含玩家受伤闪烁 + 减血效果
        }
    }


    void die()
    {
        string myScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(myScene);
    }

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

    #region 按键函数
    //返回主菜单
    public void __returnToTitle()
    {
        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }

    //跳关
    public void __ToNextLevel()
    {
        if (levelNumber == LevelData.levelData)
        {
            Debug.Log("Jump to new level!!!");
            LevelData.levelData++;
            //解锁新关卡后保存数据
            LevelData.Save();
        }

        BgmCore.StopBgm();
        //自动跳转到下一个编号的关卡
        SceneManager.LoadScene(levelNumber + 1);
    }

    //以下函数仅限菜单使用
    public void __QuitTutorial()
    {
        Application.Quit();
    }

    public void __JumpTutorial()
    {       
        LevelData.levelData = 1;            
        LevelData.Save();
        
        BgmCore.StopBgm();
        //自动跳转到下一个编号的关卡
        SceneManager.LoadScene("Title");
    }

    #endregion
}
