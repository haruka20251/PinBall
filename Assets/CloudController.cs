using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{

    //�ŏ��T�C�Y
    private float minimum = 1.0f;
    //�g��k���X�s�[�h
    private float magSpeed = 10.0f;
    //�g�嗦
    private float magnification = 0.07f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        /* ���v���O�����̉����
         *  this.transform.localScale = new Vector3(�j�F�Q�[���I�u�W�F�N�g�̃X�P�[���i�傫���j��ύX������̂Łi�j���ɕύX���e������
         *  �����i�j����X,Y,Z��������
         *  Y���F transform.localScale.y�� Y�������̃X�P�[���͂��̂܂܁@�Ƃ����Ӗ�
         *  Mathf.Sin()�F�p�x����͂���ƁA-1 ���� 1 �܂ł̒l��Ԃ��i�j�����p�x�����W�A���P�ʂ����g���Ȃ�
         *  �p�x��0�x�̂Ƃ��A�T�C���֐��̒l��0�ł��B
�@�@�@�@�@�@�p�x��90�x�i��/2���W�A���j�̂Ƃ��A�T�C���֐��̒l��1�ł��B
�@�@�@�@�@�@�p�x��180�x�i�΃��W�A���j�̂Ƃ��A�T�C���֐��̒l��0�ł��B
�@�@�@�@�@�@�p�x��270�x�i3��/2���W�A���j�̂Ƃ��A�T�C���֐��̒l��-1�ł��B
�@�@�@�@�@�@�p�x��360�x�i2�΃��W�A���j�̂Ƃ��A�T�C���֐��̒l��0�ɖ߂�܂��B
         * Time.time�F�o�ߎ��ԁi�b�P�ʁj�Athis.magSpeed�͑����iime.time * this.magSpeed�F���ԂƂƂ��ɕω�����p�x�j
         * �T�C���g�� 1 �̂Ƃ��A���̒l�� minimum + this.magnification �ƂȂ�A�ő�l�ɂȂ�܂��B
�@�@�@�@�@ �T�C���g�� -1 �̂Ƃ��A���̒l�� minimum - this.magnification �ƂȂ�A�ŏ��l�ɂȂ�܂��B
         */


        /*transform.localScale= new Vector3()=�Q�[���I�u�W�F�N�g�̃X�P�[���i�傫���j��ύX����
   �@�@�@�@* localScale��scale�ƈႢ�A�e�I�u�W�F�N�g�̃X�P�[�����ύX�����ƁA�q�I�u�W�F�N�g��localScale���e�����󂯂�i�X�P�[���͉e�����󂯂Ȃ��j
   �@�@�@�@*new Vector3(): �V����3�����x�N�g���iVector3�j���쐬 X�AY�AZ�̊e�������̃X�P�[���l���w�肷�邽�߂Ɏg�p
   �@�@�@�@*���g������
   �@�@�@�@*transform.localScale = new Vector3(x, y, z);
  �@�@�@�@�@x: X�������̃X�P�[���l
  �@�@�@�@�@y: Y�������̃X�P�[���l
  �@�@�@�@�@z: Z�������̃X�P�[���l
      �@�@* �I�u�W�F�N�g��X��������2�{�AY��������0.5�{�AZ��������1�{�ɂ���
  �@�@�@�@�@transform.localScale = new Vector3(2, 0.5f, 1);
        �@*�I�u�W�F�N�g�𓙔{�ɂ���i���̑傫���ɖ߂��j
  �@�@�@�@�@transform.localScale = Vector3.one; // Vector3.one �� new Vector3(1, 1, 1) �Ɠ���
          *���
      �@�@ *�X�P�[���l��1�̏ꍇ�A�I�u�W�F�N�g�͌��̑傫���ł��B
  �@�@�@�@�@�X�P�[���l��1���傫���ꍇ�A�I�u�W�F�N�g�͊g�傳��܂��B
  �@�@�@�@�@�X�P�[���l��1��菬�����ꍇ�A�I�u�W�F�N�g�͏k������܂��B
  �@�@�@�@�@�X�P�[���l��0���w�肷��ƁA�I�u�W�F�N�g�͂��̎������̃T�C�Y��0�ɂȂ�A�����Ȃ��Ȃ�܂��B
            �X�P�[���l�ɕ��̒l���w�肷��ƁA�I�u�W�F�N�g�͔��]���܂��B
           */
      this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
    }
}
