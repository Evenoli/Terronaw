using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyControl : MonoBehaviour {

    private Animator m_anim;
    private Rigidbody2D m_rgdbdy;

    private int hitCount;

    void OnTriggerEnter2D(Collider2D col)
    {
        m_anim.SetTrigger("Hit");
        hitCount++;

        if(hitCount >= 12)
        {
            m_rgdbdy.angularVelocity = 20f;
            m_rgdbdy.velocity = new Vector2(0, 40f);
        }
    }

    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator>();
        m_rgdbdy = GetComponent<Rigidbody2D>();
	}

}
