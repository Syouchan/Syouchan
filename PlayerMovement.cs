//作成日忘れた
//作成者　田中祥太郎
//スクリプト概要
//WASDで移動できる。speedは2f。
//左シフトを押しながらWASDのどれかを押すとspeedが7fの状態で動ける。
//しかしその状態で動き続けるとペナルティが発生するようになっている。
//内容は用意しているスライダーが８割に到達すると7fから5fまで減速するようになっており、
//スライダーの一番端に到達するまで動き続けてしまうと、３秒間左シフトの押下が不可になる（走れない）。
//左コントロールを押した状態でWASDを押すとspeedが1fの状態で移動できる。
//√２走法はできないようにスクリプトで組んでいるため、斜め走法を行ってもスピードは変わらない。
//プレイヤーのカメラからレーザーを放ち、一定距離のレーザーに触れているアイテムオブジェクトに向かって
//左クリックを押すとアイテムの取得までは完成済み。しかしアイテムの使用やUIの設定は終わっていない。


using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

//ここにコインの種類を記入　01/07追記

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 3f;//走る速度
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    sutaminaBar stam;
    private bool ShiftArrowFlag = true;//Shift押下可能フラグ
    private float cooltime;//スタミナがなくなった瞬間の時間
    private float nowtime;//現在の時間
    //Ray Player_ray; //カメラからレーザービームを出す。

    public float footStepDelay;
    bool sutaminazero = false;
    private float nextFootstep = 0;
    public int item_count;
    public int key_item = 1;//ゴールに必要なキーアイテムの総数
    [SerializeField] bool GoalFlag = false;//ゴール可能フラグ
    [SerializeField] GameObject[] itemobject;
    [SerializeField] GameObject Slider;
    [SerializeField] GameObject text;

    void Start()
    {
        stam = this.GetComponent<sutaminaBar>();
        cooltime = -5f;
    }

    void Update()
    {
        nowtime = Time.time;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //WASD入力判定　※矢印キーも入力判定に入ってしまう
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 motion = transform.right * x + transform.forward * z;
        controller.Move(motion * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
        WalkRun();//走る時の処理
        //itemget(itemobject);//アイテム取得の奴
        sutamina_hantei();
    }

    //Shiftで走行する処理と√2走行対策
    private void WalkRun()
    {
        if(Input.GetKey(KeyCode.RightArrow)&& Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            speed = 0f;
        }
        //左シフトを押している間スピードアップ
        if (((Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && sutamina_hantei() == false) ||
            (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))) && sutamina_hantei() == false || (Input.GetKey(KeyCode.LeftShift) &&
            (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))) && sutamina_hantei() == false && ShiftArrowFlag))
        {
            //スタミナがなくなりそうな時の処理
            if (PlayerScript.sutamina >= 0.8)
            {
                speed = 5f;
            }
            else
            {
                speed = 7f;
            }
        }
        else
        {
            speed = 2f;
        }
        if (((Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && sutamina_hantei() == false) ||
    (Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))) && sutamina_hantei() == false || (Input.GetKey(KeyCode.LeftControl) &&
    (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))) && sutamina_hantei() == false && ShiftArrowFlag))
        {
            speed = 1f;
            ShiftArrowFlag = false;
        }

            //ルート２走法対策
            if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) ||
            (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
        {
            speed *= 1 / Mathf.Sqrt(2); //Mathf.Sqrt(2)=√2の意味
        }
    }

    private bool sutamina_hantei()
    {
        //スタミナがなくなった時の処理
        if (PlayerScript.sutamina >= 1)
        {
            cooltime = Time.time;
            sutaminazero = true;
            return true;
        }
        if(PlayerScript.sutamina >= 0.8)//なんだろう無視するの辞めて貰って良いですか。
        {
            Slider.GetComponent<Image>().color = new Color(53, 255, 0, 255);
        }
        else
        {
            Slider.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        }
        //スタミナがなくなってから3秒経過するまでの処理
        if (nowtime - cooltime <= 5 && (sutaminazero == true))
        {
            Slider.GetComponent<Image>().color = new Color(255, 0, 0, 255);
            ShiftArrowFlag = false;//Shiftを押下不可にする
            return true;
        }
        else
        {
            Slider.GetComponent<Image>().color = new Color(0, 255, 0, 255);
            sutaminazero = false;
            ShiftArrowFlag = true;//Shiftを押下可能にする
        }
        return false;
    }
}
