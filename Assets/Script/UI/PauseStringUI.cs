using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//显示菜单中的UI字符串
public class PauseStringUI : MonoBehaviour
{   
    //是否需要展示下一关的数值
    public bool ifNext;
    private TMP_Text m_Text;

    void Start()
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex; 

        m_Text = GetComponent<TMP_Text>();
        m_Text.text = ShowLevelInfo.ChangeStr(ifNext ? levelNumber + 1 : levelNumber);
    }

  
}
