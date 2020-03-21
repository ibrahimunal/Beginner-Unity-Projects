using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject playerd;
    void Start()
    {
        playerd = GameObject.FindGameObjectWithTag("Fikret");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerd.transform.position.x, playerd.transform.position.y+1, transform.position.z);
    }
}
