using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public AudioClip newTrack;
    private AudioController audioControl;
    void Start()
    {
        audioControl = FindObjectOfType<AudioController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            door.transform.position -= new Vector3(0, 1, 0);
            if (newTrack != null)
            {
                audioControl.changeBGM(newTrack);
            }
        }
    }
}
