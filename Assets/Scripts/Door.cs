using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private Animator animator1;
    private Animator animator2;
  
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator1 = GetComponent<Animator>();
        animator2 = GetComponent<Animator>();
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
    public void LastDoor()
    {
        animator2.SetBool("LastDoor", true);
    }

   
}
