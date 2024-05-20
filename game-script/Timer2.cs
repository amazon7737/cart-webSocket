using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.Json;
using UnityEngine.Networking;



public class Timer2 : MonoBehaviour
{
    public Slider timerSlider;
    public Text timerText;
    public Text gameOverText;
    public GameObject car;
    public float gameTime;

    private bool stopTimer;

    // Start is called before the first frame update
    void Start()
    {
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopTimer){
            return;
        }

        float time = gameTime - Time.time;

        if(time<=0){
            time = 0;
            stopTimer = true;
            gameOverText.gameObject.SetActive(true);
            DisableCar();
        }

        int minutes = Mathf.FloorToInt(time/ 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60f);

        string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = textTime;
        timerSlider.value = time;

        //  if(textTime == "{0:0}"){
        //     InitDataRequest();
        // }
    }

    // IEnumerator InitDataRequest(){
    //     UnityWebRequest request = UnityWebRequest.Get("http://20.30.3.171:3000/init/player2");
    //     yield return request.SendWebRequest();
    //      request.Dispose();
    // }

    void DisableCar(){
        Car carScript = car.GetComponent<Car>();
        if(carScript != null){
            carScript.enabled = false;
        }
    }
}
