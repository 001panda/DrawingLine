using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform TarPoint;
    public GameObject SpikePre;
    public float timer;

    private bool arrive;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpikeMove", gameObject);

    }

    private void Update()
    {
        if (arrive)
        {
            GameObject spike = Instantiate(SpikePre, SpikePre.transform.position, Quaternion.identity);
            StartCoroutine("SpikeMove", spike);
        }
    }

    IEnumerator SpikeMove(GameObject tar)
    {
        arrive = false;
        while (tar.transform.position != TarPoint.position)
        {
            tar.transform.position = Vector3.Lerp(tar.transform.position, TarPoint.position, 0.01f);
            yield return null;
        }
        arrive = true;
    }

    //private void SpikeStart()
    //{

    //}
}
