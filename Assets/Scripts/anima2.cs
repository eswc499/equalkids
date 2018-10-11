using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anima2 : MonoBehaviour {
    public Animator animator;
    // Use this for initialization
    void Start()
    {

    }

    public void gogo()
    {
        animator.SetBool("IsOpen", true);


    }

    public void goback()
    {
        animator.SetBool("IsOpen", false);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
