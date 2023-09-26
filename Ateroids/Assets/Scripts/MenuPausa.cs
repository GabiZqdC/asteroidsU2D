using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool juegoPausa = false;

    public GameObject menuPausaUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausa)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
        
    }

    public void Reanudar()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        juegoPausa = false;
    }

    public void Pausar()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        juegoPausa = true;
    }

    public void Reiniciar()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        Player.SCORE = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
