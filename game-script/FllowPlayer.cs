using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FllowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset = new Vector3(0, 5, -10);

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
    }
}