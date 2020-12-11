using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform player;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip BackOff;
    public AudioClip dancingAudio;

    public bool isDancing; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position)< 3f)
        {
            if (isDancing)
            {
                animator.SetTrigger("stopDancing");
                isDancing = false;

                StartCoroutine(PlayBackOffAudio());
            }
        }
        else
        {
            if(isDancing == false)
            {
                animator.SetTrigger("dance");
            }
        }
    }


    private IEnumerator PlayBackOffAudio()
    {
        yield return new WaitForSeconds(5f);

        audioSource.clip = BackOff;
        audioSource.Play();

        yield return null;
    }
}
