using TMPro;
using UnityEngine;


public class ShowLevelInfo : MonoBehaviour
{
    private TMP_Text m_Text;
    

    private void Start()
    {
        int levelnow = LevelData.levelData;
        //超出40关（即获取了金杯银杯）按40关算
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

    
    // 用于将数字类型的关卡编号转换为标准字符格式
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
