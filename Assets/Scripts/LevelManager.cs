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
        //1�Ļ����ǿ������е�ǰ������-1����û�н�����ǰ�Ĺؿ�
        //PlayerPrefs.SetInt("Level1", 1);
        SystemManager.Instance.SetSystem("Level1", 1);

        //int nameStr=SystemManager.Instance.GetSystem("Level2");//����������һ�����⣬���Ǵ�������Awake��������֪����ִ����һ�������Ա����������Ϊ�ɽ��⴮�������updata�����У�Ҳ��������Ŀ�����Ǹ��ű���ִ�У�������System Manager�ű���ִ��
        //SystemManager.Instance.ClaerAll();//������еĴ洢��ͨ���Ĺؿ���������Ϊ1
    }
    private void Start()
    {
        //�����ӽڵ㣬��text��������
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
        //ʵ�ֱ��ش洢
        //PlayerPrefs.SetInt("Level1", 1);
        //PlayerPrefs.DeleteAll();
        //Debug.Log(PlayerPrefs.GetInt("Level1"));
    }
    public void ReturnLogin()
    {
        SceneManager.LoadSceneAsync("LoginScene");
    }
}
