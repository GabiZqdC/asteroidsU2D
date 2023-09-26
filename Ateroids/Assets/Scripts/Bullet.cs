using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    
    public float speed = 10f;
    public float maxLifeTime = 5f;
    public Vector3 targetVector;

    public static float xBorderLimit, yBorderLimit;


    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, maxLifeTime);
        yBorderLimit = Camera.main.orthographicSize + 1;
        xBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(targetVector * speed * Time.deltaTime);
        var newPos = transform.position;    //obtengo la posicion de la bala 
        if (newPos.x > xBorderLimit || newPos.x < -xBorderLimit || newPos.y > yBorderLimit || newPos.y < -yBorderLimit)  //si sale de cualquiera de los limites de la camara, desactivamos la bala para poder volver a utilizarla
            gameObject.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        Debug.Log(Player.SCORE);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }


}
