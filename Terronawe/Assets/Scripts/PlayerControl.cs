using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private bool m_facingRight;
    private Rigidbody2D m_rgdbdy;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_anim;

    public float m_moveSpeed;
    public float m_jumpHeight;


	// Use this for initialization
	void Start () {
        m_rgdbdy = GetComponent<Rigidbody2D>();
        if (!m_rgdbdy)
            print("No Rigidbody2D on character!!!");

        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (!m_spriteRenderer)
            print("No Sprite Renderer on character!!!");

        m_anim = GetComponent<Animator>();
        if (!m_anim)
            print("No Animator On Character!!!");

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rgdbdy.velocity += new Vector2(0, m_jumpHeight);
            m_anim.SetTrigger("Jump");
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            m_facingRight = true;
            m_rgdbdy.velocity = new Vector2(m_moveSpeed, m_rgdbdy.velocity.y);
            m_anim.SetBool("IsRunning", true);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            m_facingRight = false;
            m_rgdbdy.velocity = new Vector2(-m_moveSpeed, m_rgdbdy.velocity.y);
            m_anim.SetBool("IsRunning", true);
        }
        else
        {
            m_anim.SetBool("IsRunning", false);
        }

        if(Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            m_anim.SetTrigger("Punch");
        }

        if(m_anim.GetCurrentAnimatorStateInfo(0).IsTag("Punch"))
        {
            m_rgdbdy.velocity = new Vector2(0, m_rgdbdy.velocity.y);
        }

        m_spriteRenderer.flipX = !m_facingRight;
	}
}
