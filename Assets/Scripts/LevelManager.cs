using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Color color;
    private void Awake()
    {
        //1的话就是可以运行当前场景，-1就是没有解锁当前的关卡
        //PlayerPrefs.SetInt("Level1", 1);
        SystemManager.Instance.SetSystem("Level1", 1);

        //int nameStr=SystemManager.Instance.GetSystem("Level2");//在这里遇到一个问题，就是存在两个Awake函数，不知道先执行哪一个，所以报错，解决方法为可将这串代码放入updata函数中，也可以在项目设置那个脚本先执行，设置了System Manager脚本先执行
        //SystemManager.Instance.ClaerAll();//清楚所有的存储，通过的关卡重新设置为1
    }
    private void Start()
    {
        //遍历子节点，将text按序号输出
        for (int i = 1; i <= transform.childCount; i++)
        {
            string levelName=transform.GetChild(i-1).name = "Level" + i;
            transform.GetChild(i-1).GetChild(0).GetComponent<Text>().text = i.ToString();
            if (PlayerPrefs.HasKey(levelName))
            {
               // Debug.Log("wocunzai" + levelName);
            }
            else
            {
                transform.GetChild(i - 1).GetComponent<Button>().interactable = false;
                transform.GetChild(i - 1).GetChild(0).GetComponent<Text>().color = color;
            }
        }
        //实现本地存储
        //PlayerPrefs.SetInt("Level1", 1);
        //PlayerPrefs.DeleteAll();
        //Debug.Log(PlayerPrefs.GetInt("Level1"));
    }
    public void ReturnLogin()
    {
        SceneManager.LoadSceneAsync("LoginScene");
    }
}
