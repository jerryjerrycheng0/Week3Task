using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Tower_Audio : MonoBehaviour
{
    AudioSource alarmRepeater;

    // Start is called before the first frame update
    void Start()
    {
        alarmRepeater = GetComponent<AudioSource>();
    }

    public void PlayAlarmBell()
    {
        alarmRepeater.pitch = Random.Range(0.8f, 1.3f);
        alarmRepeater.Play();
    }
}
