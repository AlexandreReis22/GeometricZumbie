using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tiroManager : MonoBehaviour
{    
    [SerializeField]
    private float _speedTiro;    
    private float _timeTiroDestroy;
    private Vector2   _flipTiro;
    private bool      _atirou;

    public PlayerManager _pManager;

    private void Awake()
    {
         _pManager = FindObjectOfType<PlayerManager>().GetComponent<PlayerManager>();        
    }

    private void FixedUpdate()
    {
        _timeTiroDestroy += 1 * Time.deltaTime;

        if(_pManager.transform.localScale.x == 1 && !_atirou) 
        {
            _flipTiro = new Vector2(1, 0);
            _atirou = true;
        }
        else if(_pManager.transform.localScale.x == -1 && !_atirou)
        {
            _flipTiro = new Vector2(-1, 0);
            _atirou = true;
        }

        transform.Translate((_flipTiro * _speedTiro * Time.deltaTime));
      
        if (_timeTiroDestroy > 1.9f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        InimigoManager manager = collision.GetComponent<InimigoManager>();
        if (manager != null)
        {
            manager._vida -= (int)_pManager._dano;
            Destroy(this.gameObject);
        }
        
    }
}
