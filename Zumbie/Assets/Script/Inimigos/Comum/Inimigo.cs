using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    private InimigoManager _inimigo;    
    [SerializeField]
    private Transform _player;

    void Start()
    {
        _inimigo = GetComponent<InimigoManager>();
        _player = FindObjectOfType<PlayerManager>().GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (ManagerGeral._pause == false)
        {
            if (_inimigo._vida <= 0)
            {
                PlayerManager._xp += 15f;
                Destroy(gameObject);
            }
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _inimigo._speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, -2.05f, transform.position.z);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager player = collision.GetComponent<PlayerManager>();
        if (player != null && !player._invensivel)
        {                    
            player._vidaAtual -= _inimigo._dano;
            player._invensivel = true;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            if (player._h == 1)
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);
                
            }
            else if (player._h == -1) 
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
            } else
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(player._rb.velocity.x, 10), ForceMode2D.Impulse);
            }           
        }
    }
}
