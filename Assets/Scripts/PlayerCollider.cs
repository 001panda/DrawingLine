using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerCollider : MonoBehaviour
{
    public GameObject hitprefab;
    //开始
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Tags.COIN)
        {
            Debug.Log("Coin+1");
            UIManager.Instance.SetCount();
            Destroy(collision.gameObject);//碰撞到金币后金币消失

            collision.transform.parent.GetComponent<Door>().SingleOpenDoor();

        }
        if (collision.tag == Tags.TARGET)
        {
            UIManager.Instance.ShowWinPanel();
            UIManager.Instance.IsGmaeEnd=true;
        }
        if (collision.tag == Tags.WALL)
        {
            //Debug.Log("这是墙");
            Instantiate(hitprefab,transform.position,Quaternion.identity);//克隆原始对象返回克隆对象
            gameObject.SetActive(false);//角色碰到墙后会被隐藏
            UIManager.Instance.ShowGameOver();
        }
        if (collision.tag == Tags.KEY)
        {
            collision.transform.parent.GetComponent<Door>().OpenDoor();//拿到父物体中的Door脚本中的OpenDoor
            collision.gameObject.SetActive(false);//碰撞后隐藏开门的钥匙
        }
    }

    //结束
    //private void OnTriggerExit2D(Collider2D collision)
    //{
        
    //}
}
