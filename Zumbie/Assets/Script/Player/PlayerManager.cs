using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("Componentes")]

    public Rigidbody2D _rb;
    private SpriteRenderer _Sprite;    

    [Header("Valores de movimentacao")]

    public float        _move;    
    public int          _h;
    private bool        _flipar;

    [Header("Valores PreFixado")]

    public  float  _dano = 10f;
    public  int    _vida;
    public int     _vidaAtual;

    [Header("hud")]

    public Slider  _sliderVida;
    public Slider  _sliderXp;
    public Text    _textXp;
    public Text    _vidaIntText;

    [Header("XP")]

    public static float       _xp = 0;
    [SerializeField]
    private float            _nextLevel = 100;
    [SerializeField]
    private int              _nivel = 1;        
    public GameObject        _menuLevel;
    public bool              _upNivel;   
    public GameObject        _alertUp;

    [Header("Tiro")]

    public GameObject _tiro;
    public Transform _tiroTransform;
    public float     _timeAtaque;
    public float     _nextAtk;

    [Header("pulo")]

    [SerializeField]
    private float     _forceJump;
    [SerializeField]
    private Transform _chao;
    private bool      _checkChao;

    [Header("invensivel")]
    public bool    _invensivel;
    private float  _timeInven;

    [Header("Audio")]
    public AudioSource _cAudio;
    public AudioClip   _tiroSom;
    

    void Start()
    {
        GetComponent();
        _vidaAtual = _vida;
        _xp = 0;
    }
    
    void Update()
    {
        _checkChao = Physics2D.Linecast(transform.position, _chao.transform.position, 1 << LayerMask.NameToLayer("chao"));

        _sliderVida.value = _vidaAtual;
        _vidaIntText.text = _vidaAtual.ToString("f0");
        _timeAtaque += 1.3f * Time.deltaTime;  

        if(_invensivel) 
        {
            _timeInven += Time.deltaTime;
            _Sprite.color = Color.red;
        } 
        if(_timeInven > 0.9f)
        {
            _timeInven = 0;
            _invensivel = false;
            _Sprite.color = new Color(0.05940725f, 0.6580493f, 0.8396226f);
        }
                  
        fliping();
        menuLevel();
        BarraXp();

    }
    private void FixedUpdate()
    {
       if (!_invensivel)
       {
            _rb.velocity = new Vector2(_move * Time.deltaTime * _h, _rb.velocity.y);
       }        
    }

    public void jumping()
    {
        if( _checkChao) 
        {
            _rb.AddForce(new Vector2(_rb.velocity.x, _forceJump), ForceMode2D.Impulse);
        }        
    }

    public void atirar()
    {
        if(_timeAtaque > _nextAtk)
        {
            Instantiate(_tiro, _tiroTransform.position, Quaternion.identity);
            _cAudio.PlayOneShot(_tiroSom);
            _timeAtaque = 0;
        }            
    }

    void fliping()
    {
        if(_h == -1 && !_flipar)
        {
            _flipar = !_flipar;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        } 
        else if (_h == 1f && _flipar) 
        {
            _flipar = !_flipar;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }  

    void menuLevel()
    {
        if(_xp >= _nextLevel)
        {
            _alertUp.SetActive(true);
            _alertUp.transform.position = new Vector3(gameObject.transform.position.x - 0.6f, gameObject.transform.position.y + 0.75f,transform.position.z);
        }        
    }

    public void LevelUp()
    {
        if (_xp >= _nextLevel)
        {
            _xp = 0;
            _nivel++;
            _nextLevel += 7f / 100 * _nextLevel;
            _menuLevel.SetActive(true);
            _vida += 10;
            _vidaAtual = _vida;
            Time.timeScale = 0;
        }                
    }

    void BarraXp()
    {
        _sliderXp.maxValue = _nextLevel;
        _sliderXp.value = _xp;
        _textXp.text = _nivel.ToString();
        _sliderVida.maxValue = _vida;
    }

    private void GetComponent()
    {
        _rb = GetComponent<Rigidbody2D>();
        _Sprite = GetComponent<SpriteRenderer>();
    }
}
