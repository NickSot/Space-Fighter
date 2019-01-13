using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed = 0.2f;
    public float hp = 100;
    public GameObject explosion;
    public List<GameObject> enemies;
    public uint enemyCount = 5;

    public bool printMessage = false;
    public bool victory = false;

    void Start()
    {
        LoadSaveController.Save(SceneManager.GetActiveScene().name);

        if (AsteroidSpawner.Instance != null)
            AsteroidSpawner.Instance.RegisterPlayer(gameObject);
    }

    void OnDestroy()
    {
        if (AsteroidSpawner.Instance != null)
        {
            AsteroidSpawner.Instance.UnregisterPlayer(gameObject);
        }
    }

    void FixedUpdate()
    {
        MoveShipWithPhysics();
    }

    IEnumerable Wait() {
        yield return new WaitForSeconds(3);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level2") {
            gameObject.GetComponent<ScenarioController>().PrintMessage("What is tha... Holy shit! Those are enemy ships!!!");
        }

        if (victory) {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                gameObject.GetComponent<ScenarioController>().PrintMessage("Well done... We can proceed!");
            } else if (SceneManager.GetActiveScene().name == "Level2") {
                gameObject.GetComponent<ScenarioController>().PrintMessage("Damn it! if we don't do something we are doomed...");
            }
            StartCoroutine("Wait" , Wait());
            SceneManager.LoadScene("Intro2");
        }
        
        if (hp <= 0) {
            Instantiate(explosion, transform.position, new Quaternion());
            Destroy(gameObject);
            SceneManager.LoadScene("Main_Menu");
        }

        UpdateShootInputs();
    }

    private void UpdateShootInputs()
    {
        if (Input.GetButton("Fire1"))
        {
            GetComponent<Weapon>().Shoot();
        }
    }

    private void MoveShipWithPhysics()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float playerCameraOffset = Camera.main.transform.position.y - transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        Quaternion newRotation = Quaternion.LookRotation(mousePositionWorldSpace - transform.position);
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction = transform.rotation * direction;
        direction = direction * PlayerSpeed * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + direction);
        rb.MoveRotation(newRotation);
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("EnemyShip")) {
            Debug.Log("HERE");
            hp -= 10;
        }

        if (col.gameObject.name == "prop_asteroid_01(Clone)" || col.gameObject.name == "prop_asteroid_03(Clone)") {
            hp -= 10;
        }
    }
}