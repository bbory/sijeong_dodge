using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;//탄알 이동 속력
    private Rigidbody bulletRigidbody;// 이동에 사용할 리기드바디 컴포넌트

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody.velocity = transform.forward * speed;
        // 리기드바디의 속도= 앞쪽방향*이동속력

        Destroy(gameObject, 3f); //3초 뒤에 자신의 게임 오브젝트 파괴
    }
    void OnTriggerEnter(Collider other) // 트리커 충돌 시 자동으로 실행
    {
        if(other.tag== "Player")//충돌한 상대방 게임 오브젝트가 Player태그를 가진경우
        {
           PlayerController playerController = other.GetComponent<PlayerController>();
            //상대방 게임 오브젝트에서 Playercontroller 컴포넌트 가져오기

            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공한다면
            if (playerController != null)
            {
                playerController.Die();//상대방 Player컴포넌트 Die()메서드 실행
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
