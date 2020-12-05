using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PenguinScript : MonoBehaviour {
    private Vector3 movement;                        // 펭귄이 움직이는 방향 벡터
    private Vector3 forward;                          // 전방으로 나아가는 방향 벡터
    private Vector3 downward;                       // 밑으로 내려가는 방향 벡터
    private Vector3 backward;                        // 펭귄이 충돌했을때 뒤에서 다시 시작할때 사용하는 위치 벡터
    private float speed;                                  // 펭귄이 달리는 속도
    private Animator anim;                               // 플레이어 점프 혹은 충돌 애니메이션 구현을 위해 할당한 변수    
    private Touch TouchInput;                        // 터치입력 저장하는 변수
    private Vector3 pos;                                  // 임시로 펭귄 위치 저장하는 벡터
    private Rigidbody rb;
    
    public static bool isCollided = false;        // true : 부딪힘               false : 안부딪힘
    public static bool isSunk = false;             // true : 웅덩이 빠짐         false : 안 빠짐
    
	void Start () {
        backward = new Vector3(0.0f, 0.0f, -40.0f);
        speed = 10.0f;
        anim = GetComponent<Animator>();
        pos = Vector3.zero;
        rb = this.GetComponent<Rigidbody>();
	}
    

    void FixedUpdate()
    {
        Point_Manager.points += 1;
        if (isCollided)     // 플레이어가 충돌했을 경우
        {
            anim.SetTrigger("Trapped");
            Point_Manager.points -= 500;
            rb.isKinematic = true;
            rb.detectCollisions = false;
            //isVulnerable = false;
            pos = transform.position;
            StartCoroutine("InvulnerableTime");
            isCollided = false;
            speed /= 2.0f;
            Debug.Log("Speed : 2");
        }

        if (Input.touchCount > 0)       // 터치 입력 들어왔을 경우
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                TouchInput = Input.GetTouch(i);
                if (TouchInput.phase == TouchPhase.Began)
                    anim.SetTrigger("Jump");
            }
        }/*
        if(Input.GetKey(KeyCode.Space) == true)
            anim.SetTrigger("Jump");*/

        // 펭귄 움직임 계산
        forward = new Vector3(0.0f, 0.0f, Time.deltaTime * speed);
        movement = Vector3.zero;
        /*
        if (Input.GetKey(KeyCode.A) == true)
            movement.x = -1.0f;
        else if (Input.GetKey(KeyCode.D) == true)
            movement.x = 1.0f;
        */
        movement.x = Input.acceleration.x;
        if (movement.sqrMagnitude > 1)
            movement.Normalize();

        movement *= Time.deltaTime;
        if ((transform.position + movement * 20.0f + forward).x < 4.5f && (transform.position + movement * 20.0f + forward).x > -4.5f)
            transform.Translate(movement * 20.0f + forward);
        else
            transform.Translate(forward);
        speed += Time.deltaTime * 1 / 10;
    }
    IEnumerator InvulnerableTime()      // 무적시간 약 2초동안 펭귄이 깜빡깜빡거림
    {
        int countTime = 0;
        while (countTime < 20)
        {
            if (countTime % 2 == 0)
                Debug.Log(countTime);
            else if(countTime == 3)
                transform.position = pos + backward;
            else
                Debug.Log(countTime);

            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        //isVulnerable = true;
        speed *= 2.0f;
        rb.isKinematic = false;
        rb.detectCollisions = true;
        yield return null;
    }
}
