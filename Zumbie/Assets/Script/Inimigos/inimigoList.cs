using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoList : MonoBehaviour
{
    public int _dano;
    public int _vida;
    public float _speed;
    public int _upDano = 0;
    public int _upVida = 0;
    public int _nivel = 1;
    public int _dropXp;
    

    void Start()
    {        
         InvokeRepeating("upInimigo", 30f, 25f);          
    }    
    void Update()
    {
        switch(InimigoManager._tipo)
        {
            case "comum":
                _dano = 10 +  _nivel * _upDano;
                _speed = 3.5f;
                _vida = 50 + _nivel * _upVida;
                _dropXp = 15;
                break;

            case "corredor":
                _dano = 5 + _nivel * _upDano;
                _speed = 7.5f;
                _vida = 20 + _nivel * _upVida;
                _dropXp = 10;
                break;

            case "tank":
                _dano = 1 + _nivel * _upDano;
                _speed = 1.5f;
                _vida = 80 + _nivel * _upVida;
                _dropXp = 25;
                break;
                
            default:
                _dano = 0;
                _speed = 0;
                _vida = 0;
                break;
        }      
                  
    }    
    void upInimigo()
    {        
        _nivel++;
        _upDano = 0;
        _upVida = 0;
        int _valorUpDano = (int)(15f / 100 * _dano);
        int _valorUpVida = (int)(5f / 100 * _vida);
        _upDano = _valorUpDano;
        _upVida = _valorUpVida;
        
    }
}
