using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    
    [Header("��������")]
    [SerializeReference] float speed;
    [SerializeReference] float turnSpeed;
    [SerializeReference] Transform body;

    [Header("��չ����")]
    [SerializeReference] bool locationLimit;
    public int HP; 

    [Tooltip("Բ�����Ʒ�Χ�İ뾶")]
    [SerializeReference] float sphereDistance;

    [Tooltip("�����ƶ��Ľű�(��ѡ)")]
    [SerializeReference] PlayerMoveLimit moveLimit;

    //static�������������ű���ȡ
    public static Transform static_transform;
    public static PlayerController instance;

    Vector2 moveInput;
    //����������ת������˳��ʱ�룩�Է�ֹ����
    float turnInputLeft;
    float turnInputRight;

    //��ȡ���˺����ִ�к���������һѪ�����ֱ�Ӻ���
    public UnityEvent damagedFuctions;

    public bool isPaused;

    //�������أ��Զ��ƶ�
    int levelNumber;

    //����ģʽ������
    public bool DEBUG;

    private void Awake()
    {      
        //������ʵ��������ֹ��ű�����˳���µĿ�ָ���쳣
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
        //��Щ�ؿ����趨����ƶ���Χ
        if(locationLimit)
        {
            locLimit();
        }
        //��Щ�ؿ�����ж�����
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
        //��Ҹ��ڵ�����������ת,��δ������ʱ�Զ�Ϊȫ0
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
        #region �������
        if (DEBUG)
        {
            print("____GAMEOVER____!");
            return;
        }
        #endregion

        HP--;

        //�����ؿ�
        if (HP <= 0)
        {
            die();
        }
        //�������
        else
        {
            damagedFuctions.Invoke();  //�������������˸ + ��ѪЧ��
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

    //˳��ʱ����ת����
    public void GetTurnRInput(InputAction.CallbackContext ctx)
    {
        turnInputRight = -ctx.ReadValue<float>();
    }

    public void GetTurnLInput(InputAction.CallbackContext ctx)
    {
        turnInputLeft = ctx.ReadValue<float>();
    }

    #region ��������
    //�������˵�
    public void __returnToTitle()
    {
        BgmCore.StopBgm();

        SceneManager.LoadScene("Title");
    }

    //����
    public void __ToNextLevel()
    {
        if (levelNumber == LevelData.levelData)
        {
            Debug.Log("Jump to new level!!!");
            LevelData.levelData++;
            //�����¹ؿ��󱣴�����
            LevelData.Save();
        }

        BgmCore.StopBgm();
        //�Զ���ת����һ����ŵĹؿ�
        SceneManager.LoadScene(levelNumber + 1);
    }

    //���º������޲˵�ʹ��
    public void __QuitTutorial()
    {
        Application.Quit();
    }

    public void __JumpTutorial()
    {       
        LevelData.levelData = 1;            
        LevelData.Save();
        
        BgmCore.StopBgm();
        //�Զ���ת����һ����ŵĹؿ�
        SceneManager.LoadScene("Title");
    }

    #endregion
}
