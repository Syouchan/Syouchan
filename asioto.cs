using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asioto : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    //public AudioClip sound3;
    //public AudioClip sound4;
    AudioSource audioSource1;
    AudioSource audioSource2;
    //AudioSource audioSource3;
    //AudioSource audioSource4;
    private float seconds;

    void Start()
    {
        //Component���擾
        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = GetComponent<AudioSource>();
        //audioSource3 = GetComponent<AudioSource>();
        //audioSource4 = GetComponent<AudioSource>();
        seconds = 0f;
    }

    void Update()
    {
        walk();
        run();
    }

    void walk()
    {
        
        //W�L�[�������Ă����
        if (Input.GetKeyDown(KeyCode.W))
        {
            seconds += Time.deltaTime;
            if(seconds >= 1f)
            {
                seconds++;
                //��(sound1)��炷
                Debug.Log("soundtest1");
                audioSource1.PlayOneShot(sound1);
            }
            if (seconds >= 2f)
            {
                //���isound2�j��炷
                Debug.Log("soundtest2");
                audioSource2.PlayOneShot(sound1);
            }
        }
        else
        {
            seconds = 0f;
        }
    }
    void run()
    {
        //W�L�[�������Ă����
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
        {
            //��(sound1)��炷
            Debug.Log("soundtest1");
            audioSource1.PlayOneShot(sound1);
            //1�b���
            Invoke("DelayMethod", 0.5f);
            //���isound2�j��炷
            Debug.Log("soundtest2");
            audioSource2.PlayOneShot(sound1);
        }
        return;
    }
}