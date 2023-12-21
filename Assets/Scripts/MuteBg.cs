using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteBg : MonoBehaviour
{

    public static MuteBg Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if(Instance != null)
            Destroy(Instance);
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteBGMusic() => audioSource.Stop();
}
