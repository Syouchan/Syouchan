//�쐬���F2021/09/28
//�쐬�ҁF�c���ˑ��Y
//�X�N���v�g�T�v
//�C���X�y�N�^�[��ŃZ�b�g�����J�������A�N�e�B�u��A�N�e�B�u�ɕς��鏈��
//�X�y�[�X�������ƃA�N�e�B�u��ԂɂȂ�A�����Ă��Ȃ��ԁA��A�N�e�B�u�ɂȂ�B
//�v���C���[�̔w����ʂ����߂̃X�N���v�g�ł���B

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subcamera : MonoBehaviour
{
    public GameObject SubCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SubCamera.SetActive(true);
        }
        else
        {
            SubCamera.SetActive(false);
        }
    }
}
