using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Rigidbody2D))]
public class Player : MonoBehaviour
{
    //RigidBody
    GameObject oyuncu;
    //Bu varlar karakterin hızını ve zıplama hızını belirler... 
    [Tooltip("Karakterin ne kadar hızlı gideceğini belirler")]
    Rigidbody2D body2D;
    [Range(0,15)]
    public float playerSpeed;
    [Tooltip("Karakterin ne kadar yükseğe zıplayacağını belirler")]
    public float jumpPower;
    [Tooltip("Karakterin yere değip değmedğini belirler")]
    Transform groundCheck;
    const float GroundCheckRadius = 0.2f;
    [Tooltip("Yerin  ne oldugunu belırelr")]
    public bool isGrounded;
    public bool isFacingRight;
    public LayerMask groundLayer;
    float h,v;
    Animator animasyon;
    public int CollectedStars;
    public Text myText,Life;
    public int canSayisi;
    void Start()
    {
        canSayisi = 3;
        CollectedStars = 0;
        animasyon = GetComponent<Animator>();
        body2D = GetComponent <Rigidbody2D>();
        //GroundCheck'i bul
        groundCheck = transform.Find("GroundCheck");
    }
     void Update()
    {
        myText.text = CollectedStars.ToString();
        Life.text = canSayisi.ToString();

    }
    //Framerate'den bagımsız olarak calısır, fizik ile ilgili kodları buraya yazın
    void FixedUpdate()
    {
        if (transform.position.y < -6)
        {
            canSayisi--;
            Dead();

        }
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        body2D.velocity = new Vector2(h* playerSpeed, body2D.velocity.y);

        isGrounded = (Physics2D.OverlapCircle(groundCheck.position, GroundCheckRadius, groundLayer));
        if (h > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);

        }
        else if (h < 0) {
            transform.rotation = new Quaternion(0, 180, 0, 0);

        }
        animasyon.SetFloat("hiz", Mathf.Abs(h));
        animasyon.SetBool("yerde", isGrounded);
    }

    private void Dead()
    {

        transform.position = new Vector3(2, 0, 1);
    }

    public void Jump() {
        body2D.AddForce(new Vector2(body2D.velocity.x, jumpPower));
    

    }

     void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "obstacle") {
            canSayisi--;
        }
    }


}

