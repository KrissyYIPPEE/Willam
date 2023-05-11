using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAudio : MonoBehaviour
{
    public GameObject footstep;

    // Start is called before the first frame update
    void Start()
    {
        footstep.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Audio start
        if(Input.GetKey("w"))
        {
            Footsteps();
        }
        if(Input.GetKeyDown("a"))
        {
            Footsteps();
        }
        if (Input.GetKeyDown("s"))
        {
            Footsteps();
        }
        if (Input.GetKeyDown("d"))
        {
            Footsteps();
        }

        //Audio End
        if (Input.GetKeyUp("w"))
        {
            StopFootsteps();
        }
        if (Input.GetKeyUp("a"))
        {
            StopFootsteps();
        }
        if (Input.GetKeyUp("s"))
        {
            StopFootsteps();
        }
        if (Input.GetKeyUp("d"))
        {
            StopFootsteps();
        }
    }

    void Footsteps()
    {
        footstep.SetActive(true);
    }

    void StopFootsteps()
    {
        footstep.SetActive(false);
    }
}
