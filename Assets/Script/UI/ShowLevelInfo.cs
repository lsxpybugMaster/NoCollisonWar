using TMPro;
using UnityEngine;


public class ShowLevelInfo : MonoBehaviour
{
    private TMP_Text m_Text;
    

    private void Start()
    {
        int levelnow = LevelData.levelData;
        //����40�أ�����ȡ�˽���������40����
        levelnow = Mathf.Clamp(levelnow, 1, 40);
        int theme = levelnow / 10 + 1;
        int level = levelnow % 10;
        if(level == 0)
        {
            level = 10;
            theme--;
        }    
       
        m_Text = GetComponent<TMP_Text>();
        m_Text.text = $"{theme}-{level}";
    }

    
    // ���ڽ��������͵Ĺؿ����ת��Ϊ��׼�ַ���ʽ
    public static string ChangeStr(int n)
    {     
        int theme = n / 10 + 1;
        int level = n % 10;
        if (level == 0)
        {
            level = 10;
            theme--;
        }
        
        return  $"{theme}-{level}";
    }
}
