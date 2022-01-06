//�쐬�V���@�c���@�ˑ��Y
//��ԓ��ɂ���I�u�W�F�N�g���v���C���[�t���O�ł��}�E�X�{�^���������ꂽ��
//�I�u�W�F�N�g����ɓ����X�N���v�g����肽��������ł��B

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shutter : MonoBehaviour
{

    bool flag;
    [SerializeField] GameObject Player_ray;
    void Start()
    {

    }
    void Update()
    {
        if (transform.position.y > 4 && flag == true)
        {
            this.gameObject.transform.Translate(0, 0.002f, 0);
            Debug.Log("UP");
        }
        if (transform.position.y < 2 && flag == false)
        {
            this.gameObject.transform.Translate(0, -0.002f, 0);
            Debug.Log("Down");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("mousetrue");
            if (Input.GetMouseButton(1))
            {
                flag = true;
                Debug.Log("true");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        flag = false;
        Debug.Log("false");
    }
}