using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour {


    public float moveSpeed;
    private Animator anime;
    private bool playermoving;
    private Vector2 lastmove;
    public virtualjoystick joystick;
    private Rigidbody2D rbd2;


    // Use this for initialization
    void Start () {

        anime = GetComponent<Animator>();
        rbd2 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        lastmove = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
            
        playermoving = false;

        if (joystick.Horizontal() > 0.5f || joystick.Horizontal() < -0.5f)
        {

            transform.Translate(new Vector3(joystick.Horizontal() * moveSpeed * Time.deltaTime, 0f, 0f));
            playermoving = true;
            lastmove = new Vector2(joystick.Horizontal(), 0f);
        }

        if (joystick.Vertical() > 0.5f || joystick.Vertical() < -0.5f)
        {

            transform.Translate(new Vector3(0f, joystick.Vertical() * moveSpeed * Time.deltaTime, 0f));
            playermoving = true;
            lastmove = new Vector2(0f, joystick.Vertical());

        }

        anime.SetFloat("MoveX", joystick.Horizontal());
        anime.SetFloat("MoveY", joystick.Vertical());
        anime.SetBool("PlayerMoving", playermoving);
        anime.SetFloat("LastMoveX", lastmove.x);
        anime.SetFloat("LastMoveY", lastmove.y);

    }

    void FixedUpdate()
    {
        moveSpeed = 4f;
        rbd2.MovePosition(rbd2.position + lastmove * moveSpeed * Time.deltaTime);
    }
}
