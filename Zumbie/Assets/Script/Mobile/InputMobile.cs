using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMobile : MonoBehaviour
{
    [SerializeField]
    private PlayerManager _pManager;

    public void left()
    {
        _pManager._h = 1;
    }
    public void right()
    {
        _pManager._h = -1;
    }
    public void up() 
    {
        _pManager.jumping();
    }
    public void atirar()
    {
        _pManager.atirar();
    }
    public void zero()
    {
        _pManager._h = 0;
    }
}
