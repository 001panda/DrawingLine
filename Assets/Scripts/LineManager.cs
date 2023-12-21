using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerState
{
    Idle,//待机
    Run,//行走
}


public class LineManager : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private List<Vector2> pointList = new List<Vector2>();

    private bool isRun;

    private Transform playerPos;//玩家的位置

    //也可将speed暴露出去，但是只能在编译器看到，比较安全
    [SerializeField]
    private float speed;

    private Animator animator;

    private PlayerState state;

    private int currentIndex = 0;

    public float timer = 2f;//可自己调节多少秒后出现

    public bool gameOver;
    private bool canDraw;
    public bool Isshow;
    public AudioSource rootAudioSource;
    private Coroutine gameoverCoroutine;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerPos = GameObject.Find("Player").transform;

        animator = GameObject.Find("Player").GetComponent<Animator>();
        state = PlayerState.Idle;
    }
    private void Update()
    {
        DrawLineStart();

        DrawLineEnd();

        SetPlayerState();

        SetMouseUp();


    }
    private void SetMouseUp()
    {
        #region 鼠标抬起事件
        //鼠标抬起，玩家开始走动
        if (Input.GetMouseButtonUp(0))
        {
            isRun = true;
            canDraw = true;
            state = PlayerState.Run;
        }
        #endregion

    }
    /// <summary>
    /// 设置人物的动画状态
    /// </summary>
    public void SetPlayerState()
    {
        switch (state)
        {
            case PlayerState.Idle:
                animator.SetBool(PlayAniStateTag.IsRun, false);
                break;
            case PlayerState.Run:
                animator.SetBool(PlayAniStateTag.IsRun, true);
                break;
        }
    }
    /// <summary>
    /// 画线开始函数
    /// </summary>
    private void DrawLineStart()
    {
        if (Input.GetMouseButton(0) && !canDraw)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//获取屏幕坐标
            if (!pointList.Contains(position))
            {
                pointList.Add(position);
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
            }

        }
    }
    /// <summary>
    /// 画线结束函数
    /// </summary>
    private void DrawLineEnd()
    {
        if (isRun && !gameOver)
        {
            playerPos.position = Vector3.MoveTowards(playerPos.position, pointList[currentIndex], speed * Time.deltaTime);
            if (Vector3.Distance(playerPos.position, pointList[currentIndex]) < 0.1f)
            {
                if (currentIndex > 2)
                {
                    if (pointList[currentIndex].x > pointList[currentIndex - 1].x)
                    {
                        playerPos.localEulerAngles = new Vector3(0, 0, 0);//判断人物朝向
                    }
                    else
                    {
                        playerPos.localEulerAngles = new Vector3(0, 180, 0);
                    }
                }
                currentIndex++;
                if (currentIndex >= pointList.Count)
                {
                    currentIndex = pointList.Count - 1;//拿到List的最后一个元素
                    state = PlayerState.Idle;

                    if (!gameOver)
                    {
                        gameoverCoroutine = StartCoroutine(IsGmaeOver());//开始协程

                    }
                    else
                    {
                        StopCoroutine(IsGmaeOver());//停止协程


                    }

                }



            }
        }

    }

    /// <summary>
    /// 运用协程
    /// </summary>
    public IEnumerator IsGmaeOver()
    {

        yield return new WaitForSeconds(0.5f);
        if (!UIManager.Instance.IsGmaeEnd)
        {
            PlayerCollider.Instance.Mute();

            rootAudioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
            AudioClip audio = Resources.Load<AudioClip>("default");
            //rootAudioSource.PlayOneShot(audio);
            UIManager.Instance.ShowGameOver();

            //MuteBg.Instance.MuteBGMusic();
            //Debug.Log("是否结束");
            gameOver = true;

        }
    }


}
