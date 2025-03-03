using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotnetRetreat : MonoBehaviour
{
    [SerializeField] private float force = 5f;
    [SerializeField] private float retreatDis = 30f;

    private Rigidbody2D rb;
    private GameObject player;
    private bool isRetreat = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        if(player != null && Vector2.Distance(transform.position, player.transform.position) < retreatDis && !isRetreat) 
        {
            isRetreat = true;
            StartCoroutine(Retreat());
        }
    }
    
    IEnumerator Retreat()
    {
        rb.velocity = -1 * force * transform.up;
        yield return new WaitForSeconds(1f);
        rb.velocity = 2 * force * transform.up;
    }
}
