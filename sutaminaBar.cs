//�쐬�Ё@�c���@
//�����ʂ�X�^�~�i�p�̃X�N���v�g�ł���B

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sutaminaBar : MonoBehaviour
{
    public float speed = 8.0f;
    public Slider slider;
    Animator animator;
    //UIScript uiscript;
    public float timeToEnableInputs;

    private bool ShiftArrowFlag = true;//Shift�����\�t���O
    private float cooltime;//�X�^�~�i���Ȃ��Ȃ����u�Ԃ̎���
    private float nowtime;//���݂̎���
    

    // Start is called before the first frame update
    void Start()
    {
        //slider = GameObject.Find("Slider").GetComponent<Slider>();
        animator = GetComponent<Animator>();
        //uiscript = GameObject.Find("Canvas").GetComponent<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {

        nowtime = Time.time;//���݂̌o�ߎ��Ԃ��擾
        

        //Shift+W���������ŁAShift�������s�ɂ��鉟���\�t���O��true�̎��̏���
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && this.ShiftArrowFlag == true)
        {
            PlayerScript.sutamina = PlayerScript.sutamina + (Time.deltaTime / 10);//�f�t�H���g10
        }
        else
        {
            PlayerScript.sutamina = PlayerScript.sutamina - (Time.deltaTime / 15);//�X�^�~�i���񕜂���
        }

        

        //�X�^�~�i���Ȃ��Ȃ������̏���
        if (PlayerScript.sutamina >= 1)
        {
                   
            this.ShiftArrowFlag = false;//Shift�������s�ɂ���
            cooltime = Time.time;//�X�^�~�i���Ȃ��Ȃ����u�Ԃ̎��Ԃ��擾
        }

        //�X�^�~�i���Ȃ��Ȃ���5�b�ȏ�o�߂������̏���
        if (nowtime - cooltime >= 5 && this.ShiftArrowFlag == false)
        {
            speed = 1f;
            this.ShiftArrowFlag = true;//Shift�������\�ɂ���
        }


        if (Time.time >= this.timeToEnableInputs)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                var stick = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            }
        }
        if (PlayerScript.sutamina < 0)
        {
            speed = 0;
            //animator.SetBool("DEAD", true);
            PlayerScript.sutamina = 0;
        }
        if (PlayerScript.sutamina > 1)
        {
            PlayerScript.sutamina = 1;
        }


        //�X�^�~�i��value���Ȃ���
        //�X�^�~�i���X���C�_�[�ɔ��f�����鏈��
        slider.value = PlayerScript.sutamina;
    }

}