using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _pManager;
    
    
    void Start()
    {
        _pManager = GetComponent<PlayerManager>();
    }
    
    void Update()
    {       
            _pManager._h = (int)Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _pManager.jumping();
            }

            if (Input.GetButtonDown("Fire1") && !_pManager._upNivel)
            {
                _pManager.atirar();
            }

            if(Input.GetKeyDown(KeyCode.E)) 
            {
                _pManager.LevelUp();
                _pManager._alertUp.SetActive(false);
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
              ManagerGeral._pause = true;
            }            
    }
}
