using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    //public GameObject EnterGameBtn;
    //public GameObject QuitGameBtn;
    //����˵�ѡ�����
    public void OnMenuSelect()
    {
        SceneManager.LoadSceneAsync(SceneTags.MenuScene);
    }
    //app�˳���Ϸ
    public void QuitGame()
    {
        Application.Quit();
    }
}
