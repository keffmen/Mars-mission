using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    public float time;
    public float speed;
    public float speedturn;
    public float R;
    public float t = 2f;
    [SerializeField] GameObject Pilot;
    [SerializeField] GameObject Stone;
    [SerializeField] Camera MainCamera;
    [SerializeField] Slider Heal;
    [SerializeField] Text Info;
    Animator animator;
    [SerializeField] GameObject Reset;


    private void Start()
    {
        Time.timeScale = 1.0f;
        animator = GetComponent<Animator>();
        Reset.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Heal.value--;
    }
    void Update()
    {
        time = +time + Time.deltaTime;
        MainCamera.transform.position += new Vector3(0.0f, 0.0f, speed * time);
        Pilot.transform.position += new Vector3(0.0f, 0.0f, speed * time);
       
        R = Random.value;


        if (Input.GetKey(KeyCode.D))
        {
            if (Pilot.transform.position.x >= 8)
            {
                Debug.Log("Достигнут лимит");
                
            }
            else
            {
                animator.SetBool("Right", true);
                Pilot.transform.position += new Vector3(speedturn * time, 0.0f, 0.0f);
                Debug.Log("поворот");
                
            }

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("Right", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Pilot.transform.position.x >= -8)
            {
                animator.SetBool("Left", true);
                Pilot.transform.position += new Vector3(speedturn * -time, 0.0f, 0.0f);
                Debug.Log("поворот");
                 
            }
            else
            {
                Debug.Log("Достигнут лимит");
                
            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("Left", false);
        }
        if (time > t)
        {
            Instantiate(Stone, Pilot.transform.position + new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, 250f), Quaternion.identity);
            t = t + 4f;
            Debug.Log("Создан Камень");
            Destroy(GameObject.Find("Lp01 1(Clone)"),5);
        }

        if (Heal.value == 0)
        {
            // Игра окончена 
            Info.text = "Игра окончена";
            Time.timeScale = 0f;
            Reset.SetActive(true);
        }

    }

   public void Resetgame()
    {
         
        SceneManager.LoadScene(0);
       
    }
}
