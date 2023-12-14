using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private Animator animator1;
    //private Vector3 originPos;
    //private Vector3 tarPos;

    //private void Awake()
    //{
    //    originPos = transform.position;
    //    tarPos = new Vector3(originPos.x - 12f, originPos.y);
    //    Debug.Log($"tarPos = {tarPos}");
    //}

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator1 = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        animator.SetBool("Open", true);
    }
    public void SingleOpenDoor()
    {
        animator1.SetBool("SingleOpen", true);
        //StartCoroutine(OpenDoorIE());
    }

    //private IEnumerator OpenDoorIE()
    //{
    //    while (transform.localPosition != tarPos)
    //    {
    //        transform.localPosition = Vector3.Lerp(transform.localPosition, tarPos, 0.5f);
    //        yield return null;
    //    }
    //}
}
