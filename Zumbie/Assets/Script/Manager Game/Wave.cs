using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] _inimigo;
    public float        _timeSpawm;    
    public int          _tipoSpawm;
    public int          _localSpawm;
    [SerializeField]
    private Transform[]   _spawm;
        
    void Update()
    {
        
            _timeSpawm += 1f * Time.deltaTime;
            if (_timeSpawm > 2.95f)
            {
                _tipoSpawm = Random.Range(0, 100);
                _localSpawm = Random.Range(0, 100);
                _timeSpawm = 0;
                Spawnar();
            }       
        
    }
    
    void Spawnar()
    {
        if (_localSpawm % 2 == 0)
        {
            if (_tipoSpawm < 45)
            {
                Instantiate(_inimigo[0], _spawm[0].transform.position, transform.localRotation);
            }
            else if (_tipoSpawm < 80)
            {
                Instantiate(_inimigo[1], _spawm[0].transform.position, transform.localRotation);
            }
            else
            {
                Instantiate(_inimigo[2], _spawm[0].transform.position, transform.localRotation);
            }
        }
        else
        {
            if (_tipoSpawm < 45)
            {
                Instantiate(_inimigo[0], _spawm[1].transform.position, transform.localRotation);
            }
            else if (_tipoSpawm < 80)
            {
                Instantiate(_inimigo[1], _spawm[1].transform.position, transform.localRotation);
            }
            else
            {
                Instantiate(_inimigo[2], _spawm[1].transform.position, transform.localRotation);
            }
        }
    }
}
