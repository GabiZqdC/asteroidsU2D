using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float rotationSpeed = 100f;
    public float movementSpeed = 120f;

    private Rigidbody _rigid; 

    public GameObject bulletPrefab; 
    public GameObject bulletSpawner;


    public static int SCORE=0;
    public static float xBorderLimit, yBorderLimit;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        yBorderLimit = Camera.main.orthographicSize + 1;
        xBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {

        var newPos = transform.position;    //obtengo la posicion del jugador
        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit + 1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit - 1;
        else if(newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit + 1;
        else if(newPos.y < -yBorderLimit)
            newPos.y=yBorderLimit - 1;

        transform.position = newPos;    //actualizo la posicion del jugador

        float thrust = Input.GetAxis("Thrust")* movementSpeed * Time.deltaTime ;

        float rotation = -Input.GetAxis("Horizontal") *Time.deltaTime;

        Vector2 movementDirection = transform.right;

        transform.Rotate(Vector3.forward, rotation * rotationSpeed);

        _rigid.AddForce(thrust * movementDirection);

        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("PAIUN PAUN!!!!");
            //GameObject bullet= Instantiate(bulletPrefab, bulletSpawner.transform.position, Quaternion.identity);
            GameObject bullet = ObjectPool.instance.GetBalaPrefab();

            if(bullet != null)
            {
                bullet.transform.position = bulletSpawner.transform.position;
                bullet.SetActive(true);
            }

            Bullet balaScript = bullet.GetComponent<Bullet>();

            balaScript.targetVector = transform.right;
        }

        // _rigid.AddForce();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
