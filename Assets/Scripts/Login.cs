using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    //public GameObject EnterGameBtn;
    //public GameObject QuitGameBtn;
    //进入菜单选择界面
    public void OnMenuSelect()
    {
        SceneManager.LoadSceneAsync(SceneTags.MenuScene);
    }
    //app退出游戏
    public void QuitGame()
    {
        Application.Quit();
    }
}
