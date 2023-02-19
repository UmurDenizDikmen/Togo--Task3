using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public Material ChildColor;
    public GameObject PanelOver;
    int Point = 0;
    public TextMeshProUGUI PointText;
    Rigidbody rb;
    private bool isGameStart;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PointText.text = Point.ToString();
        Time.timeScale = 0;
        isGameStart = false;
    }
    void Update()
    {
       
        if (Input.GetMouseButton(0) && isGameStart == false)
        {
            Time.timeScale = 1;
            IsGameStart = true;
           
        }
        if (isGameStart == true)
        {
            rb.AddForce(Vector3.forward * Speed);
           
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Lightning":
                StartCoroutine(IncreaseSpeed());
                Destroy(other.gameObject);
                break;
            case "Mana":
                StartCoroutine(ManaUp());
                Destroy(other.gameObject);
                break;
            case "Collectable":
                Point++;
                PointText.text = Point.ToString();
                Destroy(other.gameObject);
                break;
            case "FinishLine":
                PanelOver.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            Speed = 2 * Speed;
            yield return new WaitForSeconds(2f);
            Speed = Speed / 2;
            break;
        }
    }
    IEnumerator ManaUp()
    {
        while (true)
        {
            transform.GetComponent<CapsuleCollider>().isTrigger = true;
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(2f);
            transform.GetComponent<CapsuleCollider>().isTrigger = false;
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = ChildColor.color;
            break;
        }

    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}