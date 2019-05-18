using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator anim;
    private int playerContact;
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Enemy")
        {
            playerContact = -1; //subtract 1 from player healh
            playerStats.updateCurrentHealth(playerContact);
            string i = "works";
            Debug.Log(collision);
        }
    }

}
