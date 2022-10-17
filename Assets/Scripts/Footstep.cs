using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    [Header("Movement")]
    [Range(0.1f, 10)]
    public float speed = 1;
    public Transform EndPosition;

    [Header("Sound")]
    public AudioSource Audio;
    public List<AudioClip> FootStepClips;
    public AudioClip DoorClip;
    private AudioClip CurrentFootStepClip;
    [Range(0,5)]
    public float FootStepDelay =1;
    private float Timer;

    private bool DoorsAreLocked = true;
    // Start is called before the first frame update
    void Start()
    {
        CurrentFootStepClip = FootStepClips[0];
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
       
        if (Vector3.Distance(transform.position, EndPosition.position) < 0.1f) // if at the door pos
        {
            if(DoorsAreLocked)
            {
                DoorsAreLocked = false;
                Audio.clip = DoorClip;
                Audio.Play();
                Destroy(transform.parent.gameObject, 2f);
            }
        }
        else // movement
        {
            if (Timer > CurrentFootStepClip.length + FootStepDelay)
            {
                Timer = 0;
                CurrentFootStepClip = FootStepClips[Random.Range(0, FootStepClips.Count)];
                Audio.clip = CurrentFootStepClip;
                Audio.Play();
            }
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, EndPosition.position, Time.deltaTime * speed);
    }

   
}
