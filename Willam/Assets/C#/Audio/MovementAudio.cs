using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAudio : MonoBehaviour
{
    public GameObject footstep;
    public GameObject sprint;


    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    void Footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
    void Sprint()
    {
        sprint.SetActive(true);
    }
    void StopSprint()
    {
        sprint.SetActive(false);
    }
}
