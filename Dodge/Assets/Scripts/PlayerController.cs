using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평축과 수직축의 입력값의 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        //실제 이동 속도를 입력값과 이동 속도를 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //vector3 속도를 (xspeed, 0, zspeed)로 고정
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리기드바디의 속도에 newVelocity를 할당
        playerRigidbody.velocity = newVelocity;
    }
    
    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gamemanager = FindObjectOfType<GameManager>();
        gamemanager.EndGame();
    }
}
