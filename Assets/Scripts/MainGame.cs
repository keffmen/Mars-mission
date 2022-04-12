using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Pilot.transform.position += new Vector3(speedturn * time, 0.0f, 0.0f);
                Debug.Log("поворот");
            }

        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Pilot.transform.position.x >= -8)
            {

                Pilot.transform.position += new Vector3(speedturn * -time, 0.0f, 0.0f);
                Debug.Log("поворот");
            }
            else
            {
                Debug.Log("Достигнут лимит");
            }
        }

        if (time > t)
        {
            Instantiate(Stone, Pilot.transform.position + new Vector3(Random.Range(-8.0f, 8.0f), 0.0f, 250f), Quaternion.identity);
            t = t + 4f;
            Debug.Log("Создан Камень");
        }



    }
}
