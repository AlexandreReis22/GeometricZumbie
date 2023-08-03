using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuPrincipal : MonoBehaviour
{
    public Text _record;    

    private void Update()
    {
        _record.text = PlayerPrefs.GetInt("pontos").ToString();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
