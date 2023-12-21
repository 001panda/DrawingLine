using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public GameObject hitprefab;
    private AudioSource audioSourcecoin;
    public AudioSource audioSourcedefault;
    private AudioSource audioSourcevoctory;

    private AudioSource rootAudioSource1;
    public  AudioSource muteBg;
    public static PlayerCollider Instance;
    private LineManager lineManager;


    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        audioSourcecoin = GetComponent<AudioSource>();
        audioSourcedefault = GetComponent<AudioSource>();
        audioSourcevoctory = GetComponent<AudioSource>();

        rootAudioSource1 = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        muteBg = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        lineManager = GameObject.FindGameObjectWithTag("LineManager").GetComponent<LineManager>();
    }

    //开始
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.COIN)
        {
            AudioClip audioClip = Resources.Load<AudioClip>("ding");
            rootAudioSource1.PlayOneShot(audioClip);
            Debug.Log("Coin+1");
            UIManager.Instance.SetCount();
            Destroy(collision.gameObject);//碰撞到金币后金币消失

            collision.transform.parent?.GetComponent<Door>().SingleOpenDoor();

        }
        
        if (collision.tag == Tags.OPENDOORKEY)
        {
            UIManager.Instance.SetCount();
            Destroy(collision.gameObject);
        }
        if (collision.tag == Tags.WALL)
        {
            //lineManager.StopCoroutine(lineManager.IsGmaeOver());
            //StartCoroutine(IsGmaeOver1());
            //Debug.Log("这是墙");
            Instantiate(hitprefab,transform.position,Quaternion.identity);//克隆原始对象返回克隆对象
            if (UIManager.Instance.IsGmaeEnd)
            {
                return;
            }
            Mute();

            //audioSourcedefault.playOnAwake = true;
            UIManager.Instance.ShowGameOver();
            AudioClip audioClip = Resources.Load<AudioClip>("default");
            rootAudioSource1.PlayOneShot(audioClip);

            gameObject.SetActive(false);//角色碰到墙后会被隐藏


        }
        if (collision.tag == Tags.TARGET)
        {
            if (UIManager.Instance.GetAllCoins)
            {
                
                UIManager.Instance.ShowWinPanel();
                AudioClip audioClip = Resources.Load<AudioClip>("voctory");
                audioSourcevoctory.PlayOneShot(audioClip);
                Mute();

                UIManager.Instance.IsGmaeEnd = true;
            }
        }
        if (collision.tag == Tags.KEY)
        {
            collision.transform.parent.GetComponent<Door>().OpenDoor();//拿到父物体中的Door脚本中的OpenDoor
            collision.gameObject.SetActive(false);//碰撞后隐藏开门的钥匙
        }
        if (collision.tag == Tags.OPENDOORKEY)
        {
            collision.transform.parent.GetComponent<Door>().LastDoor();//拿到父物体中的Door脚本中的OpenDoor
            collision.gameObject.SetActive(false);//碰撞后隐藏开门的钥匙
        }
                
    }
    public void Mute()
    {
        muteBg.Stop();
    }
    public void QuitUI()
    {
        
    }


}
