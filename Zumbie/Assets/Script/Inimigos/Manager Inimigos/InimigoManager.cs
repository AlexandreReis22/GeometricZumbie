using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoManager : MonoBehaviour
{
    public static string _tipo;
    public string _tipoAtual;
    public int _dano;
    public int _vida;
    public int _dropXp;
    public float _speed;
    public inimigoList _inimigoList;

    private void Awake()
    {
        _tipo = _tipoAtual;
    }
    void Start()
    {
        _inimigoList = FindObjectOfType<Wave>().GetComponent<inimigoList>();
        _dano = _inimigoList._dano;
        _vida = _inimigoList._vida;
        _speed = _inimigoList._speed;
        _dropXp = _inimigoList._dropXp;
    }    
}
