using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudPause : MonoBehaviour
{
    public ManagerGeral _mGeral;
    public PlayerManager _pManager;
    public Text _vidaIntText;
    public Text _danoIntText;

    void Start()
    {
        
    }

    
    void Update()
    {
        _danoIntText.text = _pManager._dano.ToString("f2");
        _vidaIntText.text = _pManager._vida.ToString("f2");
    }
    public void GameRetorn()
    {
        ManagerGeral._pause = false;
        _mGeral._menuPause.SetActive(false);
        Time.timeScale = 1;
    }
}
