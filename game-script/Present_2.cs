using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.Json;
using UnityEngine.Networking;


public class Present_2 : MonoBehaviour
{
    Rigidbody rigid;
    float jumpforce = 5f; 
    public float rotationSpeed = 100f;

     void OnTriggerEnter(Collider col){        
        if(col.gameObject.name == "Body2") {
            GameObject.Find("GameManager").SendMessage("Player2_GetPresent");
            this.rigid.AddForce(transform.up * this.jumpforce, ForceMode.VelocityChange);
            Invoke("DestroyObject", 0.3f);
        }
        StartCoroutine(request());
       

    }

    IEnumerator request(){
        // string[] data = new string[{"type" : 0, "coin": 1}];

        //   List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        // formData.Add( new MultipartFormDataSection("{type: 0, coin: 1}") );
        // formData.Add( new MultipartFormFileSection("my file data", "myfile.txt") );

                WWWForm form = new WWWForm();
                string type = "1";
            string coin = "1";
            form.AddField("type" , type);
            form.AddField("coin" , coin);
        
        UnityWebRequest request = UnityWebRequest.Post("http://20.30.3.171:3000/player",form);
         yield return request.SendWebRequest();
          request.Dispose();

    }

   

    void DestroyObject(){
        DestroyObject(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
