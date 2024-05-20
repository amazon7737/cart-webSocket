using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Text.Json;
public class GameManager : MonoBehaviour
{
    int player1_PresentCount = 0;
    int player2_PresentCount = 0;
    int presentCount = 0;
    public Text player1_PresentText;
    public Text player2_PresentText;
    public Vector3 playerPosition;
    public int score;
    public Text winText1;
    public Text winText2;
    public Text loseText1;
    public Text loseText2;
    public Text tieText1;
    public Text tieText2;
    public GameObject car;
    public GameObject car2;


    public void Player1_GetPresent() {
        player1_PresentCount++;
        player1_PresentText.text = "Player1_SCORE: " + player1_PresentCount;
        Debug.Log("Player1_Score: " + player1_PresentCount);
        presentCount--;
    }

    public void Player2_GetPresent() {
        player2_PresentCount++;
        player2_PresentText.text = "Player2_SCORE: " + player2_PresentCount;
        Debug.Log("Player2_Score: " + player2_PresentCount);
        presentCount--;
    }

    public void RestartGame(){
        Application.LoadLevel("Mario_test");
    }


    // Start is called before the first frame update
    void Start()
    {
        // gameStartRequest();
        presentCount = 10;
        winText1.gameObject.SetActive(false);
        winText2.gameObject.SetActive(false);
        loseText1.gameObject.SetActive(false);
        loseText2.gameObject.SetActive(false);
        tieText1.gameObject.SetActive(false);
        tieText2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (presentCount == 0) {
// UnityWebRequestGET();
            if (player1_PresentCount > player2_PresentCount){
                winText1.gameObject.SetActive(true);
                loseText2.gameObject.SetActive(true);
            }
            if (player1_PresentCount == player2_PresentCount) {
                tieText1.gameObject.SetActive(true);
                tieText2.gameObject.SetActive(true);
            }
            if (player1_PresentCount < player2_PresentCount) {
                winText2.gameObject.SetActive(true);
                loseText1.gameObject.SetActive(true);
            }
            
            DisableCar();
            DisableCar2();

        }
    }

    void DisableCar(){
        Car carScript = car.GetComponent<Car>();
        if(carScript != null){
            carScript.enabled = false;
        }
    }

    void DisableCar2(){
        Car2 car2Script = car2.GetComponent<Car2>();
        if(car2Script != null){
            car2Script.enabled = false;
        }
    }

    //   IEnumerator gameEndRequest(){
    //     UnityWebRequest request = UnityWebRequest.Get("http://20.30.3.171:3000/gameEnd");
    //     yield return request.SendWebRequest();
    // }



    //  IEnumerator UnityWebRequestGET()
    // {
        // GET 방식
        // string apikey = "발급받은 API키를 넣는다.";
        // string url = "https://api.neople.co.kr/df/servers?apikey=" + apikey;

		// UnityWebRequest에 내장되있는 GET 메소드를 사용한다.
    //     UnityWebRequest www = UnityWebRequest.Get("htto://20.30.3.171:3000/gameEnd");

    //     yield return www.SendWebRequest();  // 응답이 올때까지 대기한다.

    //     if (www.error == null)  // 에러가 나지 않으면 동작.
    //     {
    //         Debug.Log(www.downloadHandler.text);
    //     }
    //     else
    //     {
    //         Debug.Log("error");
    //     }
    // }
}
