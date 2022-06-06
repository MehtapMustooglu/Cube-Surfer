using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontalSpeed = 10f;
    float speedForward =8f;
    float moveVectorX;
    float xMin = -3.35f;
    float xMax = 5.85f;
    

    void Start()
    {
        PlayerPrefs.SetFloat("forward", speedForward);
       
    }

    // Update is called once per frame
    void Update()
    { 
        MovePlayerForward();
        MovePlayerTowardsX();
    }
    void MovePlayerTowardsX()
    {
        moveVectorX = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal")!=0)
        transform.position += new Vector3(moveVectorX, 0, 0);
        float xposision = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xposision, transform.position.y, transform.position.z);
    }
    void MovePlayerForward()
    {
        transform.Translate(0, 0, PlayerPrefs.GetFloat("forward") * Time.deltaTime);
    }
}
