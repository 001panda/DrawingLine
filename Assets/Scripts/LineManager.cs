using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerState
{
    Idle,//����
    Run,//����
    Attack,//����
}


public class LineManager : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private List<Vector2> pointList = new List<Vector2>();

    private bool isRun;

    private Transform playerPos;//��ҵ�λ��

    //Ҳ�ɽ�speed��¶��ȥ������ֻ���ڱ������������Ƚϰ�ȫ
    [SerializeField]
    private float speed;

    private Animator animator;

    private PlayerState state;
    
    private int currentIndex = 0;

    public float timer = 2f;//���Լ����ڶ���������

    private bool gameOver;
    private bool canDraw;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerPos = GameObject.Find("Player").transform;

        animator = GameObject.Find("Player").GetComponent<Animator>();
        state=PlayerState.Idle;
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
        #region ���̧���¼�
        //���̧����ҿ�ʼ�߶�
        if (Input.GetMouseButtonUp(0))
        {
            isRun = true;
            canDraw = true;
            state = PlayerState.Run;
        }
        #endregion

    }
    /// <summary>
    /// ��������Ķ���״̬
    /// </summary>
    private void SetPlayerState()
    {
        switch (state) 
        {
            case PlayerState.Idle:
                animator.SetBool(PlayAniStateTag.IsRun, false);
                break;
            case PlayerState.Run:
                animator.SetBool(PlayAniStateTag.IsRun, true);
                break;
            case PlayerState.Attack:
                //�������߼���ʲô
                break;
        }
    }
    /// <summary>
    /// ���߿�ʼ����
    /// </summary>
    private void DrawLineStart()
    {
        if (Input.GetMouseButton(0)&&!canDraw)
        {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);//��ȡ��Ļ����
            if (!pointList.Contains(position))
            {
                pointList.Add(position);
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, position);
            }

        }
    }
    /// <summary>
    /// ���߽�������
    /// </summary>
    private void DrawLineEnd()
    {
        if (isRun&&!gameOver)
        {
            playerPos.position = Vector3.MoveTowards(playerPos.position, pointList[currentIndex], speed * Time.deltaTime);
            if (Vector3.Distance(playerPos.position, pointList[currentIndex]) < 0.1f)
            {
                if (currentIndex > 2)
                {
                    if (pointList[currentIndex].x > pointList[currentIndex - 1].x)
                    {
                        playerPos.localEulerAngles = new Vector3(0, 0, 0);//�ж�������
                    }
                    else
                    {
                        playerPos.localEulerAngles = new Vector3(0, 180, 0);
                    }
                }
                currentIndex++;
                if (currentIndex >= pointList.Count)
                {
                    currentIndex = pointList.Count - 1;//�õ�List�����һ��Ԫ��
                    state = PlayerState.Idle;//��������ʱ������Ϊidle״̬
                    if (!gameOver)
                    {
                        StartCoroutine(IsGmaeOver());//��ʼЭ��
                    }
                    else
                    {
                        StopCoroutine(IsGmaeOver());//ֹͣ�߳�
                    }

                }
            }
        }
    }
    /// <summary>
    /// ����Э��
    /// </summary>
    IEnumerator IsGmaeOver()
    {
        yield return new WaitForSeconds(timer);
        if(!UIManager.Instance.IsGmaeEnd)
        {
            UIManager.Instance.ShowGameOver();
            //Debug.Log("�Ƿ����");
            gameOver = true;
        }
    }


}
