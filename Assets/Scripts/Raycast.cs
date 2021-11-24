using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Raycast : MonoBehaviour

{
    public Text time;
    private bool isMenuClicked;
    public int totalTime;
    public int maxtime;
    public bool isWorking;
    public int count;
    public float nextTime;
    public float pauseTime;
    private float timePercent
    {
        get {return (float) totalTime / maxtime; }
    }

    void Start()
    {
        isMenuClicked = false;
        maxtime = totalTime;
        nextTime = 0;
        pauseTime = 1f;
        isWorking = false;
    }

    void Update()
    {       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);

        RaycastHit hit;

        if (isWorking == true)
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + pauseTime;

                if (totalTime >= 0)
                {
                    totalTime--;
                }
                            
                if (totalTime < 0)
                {
                    totalTime = 0;
                }
                time.text = totalTime.ToString();
            }
            
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit) == true)
            {
                var selection =  hit.transform;

                Debug.DrawRay(ray.origin,ray.direction*100, Color.red);
                Debug.Log("El rayo toca con " + hit.transform.gameObject.tag);

                Debug.Log(hit.transform.gameObject.tag);
            
                if (selection.CompareTag("Cube1"))
                {
                    count = 1;
                }

                if (selection.CompareTag("Sphere"))
                {
                    count = 2;
                }

                if (selection.CompareTag("Cube2"))
                {
                    count = 3;
                }
                isWorking = true;
                StartCoroutine(Countdown());
            }
        }    
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5f);
        
        if (count == 1)
        {
            SceneManager.LoadScene("Scene1 1");
        }

        if (count == 2)
        {
            SceneManager.LoadScene("Scene1 2");
        }

        if (count == 3)
        {
            SceneManager.LoadScene("Scene1 3");
        }
    }
}