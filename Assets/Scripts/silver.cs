using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silver : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Fikret").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fikret") {
            Debug.Log(this.name);
            player.CollectedStars++;
            Destroy(this.gameObject);



        }



        }
    }

