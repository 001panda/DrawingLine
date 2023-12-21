using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;//����Ϊ����ģʽ
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
        //Debug.Log("�õ�btn");
        //��Ӱ�ť�¼�
        closeBtn.onClick.AddListener(OnClose);
        gameOverMenuBtn.onClick.AddListener(OnMenu);
        winMenuBtn.onClick.AddListener(OnMenu);
        winBtn.onClick.AddListener(OnNext);
        //returnBtn.onClick.AddListener(ReturnLogin);
    }

    /// <summary>
    /// ��ʾʧ�ܵ����
    /// </summary>
    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }
    /// <summary>
    /// ��ʾ�ɹ������
    /// </summary>
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
    
    /// <summary>
    /// ����close��ť���¿�ʼ��Ϸ
    /// </summary>
    public void OnClose()
    {
        int id= SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(id);
        //Debug.Log("���¿�ʼ��Ϸ ");
    }
    /// <summary>
    /// �ص��˵�����
    /// </summary>
    public void OnMenu()
    {
        SceneManager.LoadSceneAsync("MenuScene");//Ҳ��ͨ������1�л�����
        //Debug.Log("�ص��˵�����");
    }
    /// <summary>
    /// �������һ��
    /// </summary>
    public void OnNext()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string [] nameList=sceneName.Split("l");//�ַ�����ȡ
        //Debug.Log("diyigeshuzu" + nameList[0] + "dierge" + nameList[1]);
        //sceneName.Substring(0,3);//�ַ�����ȡ���ӵڵ�0����ʼ����Ҫ��������
        int index = int.Parse(nameList[1])+1;//
        string nextScene = nameList[0]+"l"+index;
        SystemManager.Instance.SetSystem(nextScene, 1);//��������

        SceneManager.LoadSceneAsync(nextScene);//��ת����һ������
        //SystemManager.Instance.ClaerAll();

    }
    /// <summary>
    /// ���÷���
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
        { // ����Ƿ���Esc��
            SceneManager.LoadSceneAsync("MenuScene");
        }
    }
}
