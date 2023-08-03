using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgrade : MonoBehaviour
{
    public PlayerManager _pManager;
    public Text[] _niveisText;
    public int[] _niveis;

    public void UpDano()
    {
        _pManager._dano += 8f / 100 * _pManager._dano;        
        _pManager._menuLevel.SetActive(false);
        _pManager._upNivel = false;
        _niveis[0]++;
        _niveisText[0].text = _niveis[0].ToString();
        Time.timeScale = 1;
    }
    public void UpSpeedAtk()
    {
        if (_niveis[1] < 5)
        {
            _pManager._nextAtk -= 0.05f;
            _pManager._menuLevel.SetActive(false);
            _pManager._upNivel = false;
            _niveis[1]++;
            _niveisText[1].text = _niveis[1].ToString();
            Time.timeScale = 1;
        }
        else
        {
            _niveisText[1].text = "Max";
            UpDano();
        }        
    }     
}
