using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerCollider : MonoBehaviour
{
    public GameObject hitprefab;
    //��ʼ
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.COIN)
        {
            Debug.Log("Coin+1");
            UIManager.Instance.SetCount();
            Destroy(collision.gameObject);//��ײ����Һ�����ʧ

            collision.transform.parent.GetComponent<Door>().SingleOpenDoor();

        }
        if (collision.tag == Tags.TARGET)
        {
            UIManager.Instance.ShowWinPanel();
            UIManager.Instance.IsGmaeEnd=true;
        }
        if (collision.tag == Tags.WALL)
        {
            //Debug.Log("����ǽ");
            Instantiate(hitprefab,transform.position,Quaternion.identity);//��¡ԭʼ���󷵻ؿ�¡����
            gameObject.SetActive(false);//��ɫ����ǽ��ᱻ����
            UIManager.Instance.ShowGameOver();
        }
        if (collision.tag == Tags.KEY)
        {
            collision.transform.parent.GetComponent<Door>().OpenDoor();//�õ��������е�Door�ű��е�OpenDoor
            collision.gameObject.SetActive(false);//��ײ�����ؿ��ŵ�Կ��
        }
    }

    //����
    //private void OnTriggerExit2D(Collider2D collision)
    //{
        
    //}
}
