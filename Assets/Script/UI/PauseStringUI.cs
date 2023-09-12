using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//��ʾ�˵��е�UI�ַ���
public class PauseStringUI : MonoBehaviour
{   
    //�Ƿ���Ҫչʾ��һ�ص���ֵ
    public bool ifNext;
    private TMP_Text m_Text;

    void Start()
    {
        int levelNumber = SceneManager.GetActiveScene().buildIndex; 

        m_Text = GetComponent<TMP_Text>();
        m_Text.text = ShowLevelInfo.ChangeStr(ifNext ? levelNumber + 1 : levelNumber);
    }

  
}
