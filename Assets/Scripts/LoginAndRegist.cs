using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginAndRegist : MonoBehaviour
{
    private readonly string url = "http://47.92.94.83:8949/api";
    public InputField LoginAccountInput;
    public InputField LoginPasswordInput;
    public InputField RegistAccountInput;
    public InputField RegistPasswordInput;

    public void Login()
    {
        string account = LoginAccountInput.text;
        string password = LoginPasswordInput.text;
        if (string.IsNullOrEmpty(account))
        {
            Debug.LogError("¥ÌŒÛ");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            Debug.LogError("¥ÌŒÛ");
            return;
        }
        StartCoroutine(Upload(true, account, password));
    }
    public void Resgit()
    {
        string account = RegistAccountInput.text;
        string password = RegistPasswordInput.text;
        if (string.IsNullOrEmpty(account))
        {
            Debug.LogError("’À∫≈Œ™ø’");
            return;
        }
        //Debug.Log("zhucechenggong");
        //StartCoroutine(Upload(false, account, password));

    }

    IEnumerator Upload(bool isLogin, string account, string pwd)
    {
        WWWForm formData = new WWWForm();
        formData.AddField("userAccount", account);
        formData.AddField("userPwd", pwd);

        string reqUrl = isLogin ? $"{url}/login" : $"{url}/register";
        UnityWebRequest www = UnityWebRequest.Post(reqUrl, formData);
        yield return www.SendWebRequest();
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.downloadHandler.text);
            string json = www.downloadHandler.text;
            Response<User> response = JsonUtility.FromJson<Response<User>>(json);
            if (response.code == 200)
            {
                // TODO º”‘ÿ”Œœ∑≥°æ∞

                SceneManager.LoadSceneAsync("LoginScene");
            }
            Debug.Log(response.message);
        }
        else
            Debug.LogError(www.error);
        www.Dispose();
    }
    public void GoLogin()
    {
        SceneManager.LoadSceneAsync("LoginCounter");
    }
    public void ReturnRegist()
    {
        SceneManager.LoadSceneAsync("RegistCounter");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
