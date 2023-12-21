using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;//设置为单例模式
    public GameObject gameOver;
    public GameObject winPanel;

    private Button closeBtn;
    private Button gameOverMenuBtn;
    private Button winBtn;
    private Button winMenuBtn;
    //public Button returnBtn;

    public Text countText;
    private int total=0;

    public bool IsGmaeEnd;

    private Transform[] coins;
    public bool GetAllCoins;

    private void Awake()
    {
        if (Instance == null)
        {
            
            Instance = this;
        }
    }
    private void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin").Select(item => item.transform).ToArray();
        Debug.Log($"Conins Length = {coins.Length}");
        gameOver = transform.Find("GameOver").gameObject;
        winPanel = transform.Find("WinPanel").gameObject;

        closeBtn =gameOver.transform.Find("Close").GetComponent<Button>();
        gameOverMenuBtn =gameOver.transform.Find("Menu").GetComponent<Button>();
        winBtn = winPanel.transform.Find("WinNext").GetComponent<Button>();
        winMenuBtn=winPanel.transform.Find("Menu").GetComponent<Button> ();
        //returnBtn=returnBtn.transform.Find("Return").GetComponent <Button>();
        //Debug.Log("拿到btn");
        //添加按钮事件
        closeBtn.onClick.AddListener(OnClose);
        gameOverMenuBtn.onClick.AddListener(OnMenu);
        winMenuBtn.onClick.AddListener(OnMenu);
        winBtn.onClick.AddListener(OnNext);
        //returnBtn.onClick.AddListener(ReturnLogin);
    }

    /// <summary>
    /// 显示失败的面板
    /// </summary>
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    /// <summary>
    /// 显示成功的面板
    /// </summary>
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
    
    /// <summary>
    /// 按下close按钮重新开始游戏
    /// </summary>
    public void OnClose()
    {
        int id= SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(id);
        //Debug.Log("重新开始游戏 ");
    }
    /// <summary>
    /// 回到菜单界面
    /// </summary>
    public void OnMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");//也可通过索引1切换场景
        //Debug.Log("回到菜单界面");
    }
    /// <summary>
    /// 点击后下一关
    /// </summary>
    public void OnNext()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string [] nameList=sceneName.Split("l");//字符串截取
        //Debug.Log("diyigeshuzu" + nameList[0] + "dierge" + nameList[1]);
        //sceneName.Substring(0,3);//字符串截取，从第第0个开始，需要保留三个
        int index = int.Parse(nameList[1])+1;//
        string nextScene = nameList[0]+"l"+index;
        SystemManager.Instance.SetSystem(nextScene, 1);//保存数据

        SceneManager.LoadSceneAsync(nextScene);//跳转到下一个场景
        //SystemManager.Instance.ClaerAll();

    }
    /// <summary>
    /// 设置分数
    /// </summary>
    public void SetCount()
    {
        total++;
        countText.text=total.ToString();
        if (total == coins.Length)
            GetAllCoins = true;
    }

    //public void ReturnLogin()
    //{
    //    SceneManager.LoadSceneAsync("LoginScene");
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { // 检查是否按下Esc键
            SceneManager.LoadSceneAsync("MenuScene");
        }
    }
}
