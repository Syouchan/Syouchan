using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SELECT : MonoBehaviour
{
    public GameObject[] select_item;//�z��
    private float scroll;
    int i = 0;
    private void Start()
    {
        select_item[i].SetActive(true);
    }
    private void Update()
    {
        //�}�E�X�z�C�[���̉�]�̎擾�������l��0.1�ׂ̈�10
        scroll = Input.GetAxis("Mouse ScrollWheel") * 10;

        //�}�E�X�z�C�[���𓮂������Ƃ�
        if (scroll != 0)
        {
            //�I���A�C�e���̕ύX
            if (i < select_item.Length - 1 && i > 0)
            {
                if(scroll > 0) i++;
                else i--;
            }
            else if (i <= 0 && scroll <= 0) i = select_item.Length - 1;
            
            else if(i == 0 && scroll > 0) i += (int)scroll; 
            
            else if(i == select_item.Length -1 && scroll < 0) i -= 1;
            
            else i = 0;
            //�Z���N�^�[�̃A�N�e�B�u��Ԃ̕ύX
            for(int j= 0; j < select_item.Length; j++)
            {
                select_item[j].SetActive(false);
            }
            select_item[i].SetActive(true);
            scroll = 0;
        }

    }
}
