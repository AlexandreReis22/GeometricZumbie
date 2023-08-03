using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerGeral : MonoBehaviour
{
    [Header("Text")]
    public Text _timeText;
    public Text _PontoText;

    [Header("Timers")]
    public static float _timeGame;
    public static int  _timeInt;

    [Header("Menus")]
    public GameObject _menuMorte;
    public GameObject _menuPause;

    [Header("Pause")]
    public static bool _pause;

    [Header("Componnets")]
    [SerializeField]
    private PlayerManager _pManager;

    [Header("Record")]
    public int        _recordAtual;
    public static int        _recordAnterior = 0;
    

    void Start()
    {
        Time.timeScale = 1;
        _timeGame = 0;        
    }
    
    void FixedUpdate()
    {        
        _recordAtual = _timeInt;

        if(_recordAnterior < _recordAtual && _pManager._vidaAtual <= 0)
        {
            _recordAnterior = _recordAtual;
            PlayerPrefs.SetInt("pontos", _recordAnterior);
        }        

        if (_pManager._vidaAtual <= 0)
        {            
            _menuMorte.SetActive(true);
            _PontoText.text = _timeText.text;
            Time.timeScale = 0;                      
        }
        else
        {           
            _timeGame += Time.deltaTime;
            _timeInt = (int)_timeGame;
            _timeText.text = _timeInt.ToString();               
        }  
        
        if(_pause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
        }         
    }  
    
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    

    public void MenuPrin() 
    {
        SceneManager.LoadScene(0);
    }

    public void sair()
    {
        Application.Quit();
    }
}
