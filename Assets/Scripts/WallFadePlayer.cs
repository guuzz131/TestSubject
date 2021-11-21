using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFadePlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private BoxCollider2D boxInFront;
    [SerializeField] private BoxCollider2D boxBehind;
    Renderer _renderer;
    SpriteRenderer _spriteRenderer;

    bool inFront;
    bool doOnce1 = true;
    bool doOnce2 = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _renderer = GetComponent<Renderer>();
        //_spriteRenderer = GetComponent<SpriteRenderer>();
        doOnce1 = true;
        doOnce2 = true;
    }
    void Update()
    {
        _renderer.material.SetVector("_CharacterPos", new Vector3(player.position.x, player.position.y + .1f, player.position.z));

        /*
        if (player.position.y > transform.position.y + .5f)
        {
            

            if (doOnce1)
            {
                inFront = false;
                boxInFront.isTrigger = true;
                boxBehind.enabled = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, -5.5f);
                doOnce1 = false;
                doOnce2 = true;
                
            }
        }
        else
        {
            if (doOnce2)
            {
                _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 11);
                transform.position = new Vector3(transform.position.x, transform.position.y, 1);
                inFront = true;
                boxInFront.isTrigger = false;
                boxBehind.enabled = false;
                doOnce2 = false;
                doOnce1 = true;
            }
        }*/

        
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, .7f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.g, _spriteRenderer.color.b, 1);
        }
    }*/
}