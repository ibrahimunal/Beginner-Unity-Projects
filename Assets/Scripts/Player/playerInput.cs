using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{

    Player player;


    void Start()
    {

        player=GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && player.isGrounded==true)
            player.Jump();
        
    }
}
