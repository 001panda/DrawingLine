using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public Button btn;
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(LoadSceneNext);
    }
    public void LoadSceneNext()
    {
        SceneManager.LoadSceneAsync(gameObject.name);
    }
}
