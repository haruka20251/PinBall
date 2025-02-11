using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //�}�e���A�������锠
    Material myMaterial;
    //Emission�̍ŏ��l�̖��邳(Emission:������o�������)
    private float minEmission = 0.2f;
    //Emission�̋��x�imagEmission �F���邳�̋����j
    private float magEmission = 2.0f;
    //�p�x�i���z�I�Ȋp�x�j
    //�T�C���֐����g���Ď����I�ȕω�����邽�߂ɁA�p�x���K�v�����A
    //�I�u�W�F�N�g�̎��ۂ̉�]�p�x���g���K�v�͂Ȃ��̂ŉ��z�I�Ȋp�x���g��
    private int degree = 0;
    //�������x
    private int speed = 5;

    /* �^�[�Q�b�g�̃f�t�H���g�̐F
     * Color: Unity�ŐF���������߂̃f�[�^�^
     * defaultColor: �ϐ���
     * Color.white: Unity�ɒ�`����Ă��锒�F��\���萔
     * �Q�[���I�u�W�F�N�g��UI�v�f�Ȃǂ̐F������������ۂɁA�f�t�H���g�̐F�Ƃ��Ĕ���ݒ肷�邽�߂Ɏg�p
     */
    Color defaultColor = Color.white;

    // Start is called before the first frame update
    void Start()//Start�֐��Ń^�[�Q�b�g�����F�Ɍ��邩�����߂�
    {

        // �^�O�ɂ���Č��点��F��ς���
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;
        }

        //�I�u�W�F�N�g�ɃA�^�b�`���Ă���Material���擾
        this.myMaterial = GetComponent<Renderer>().material;

        //�I�u�W�F�N�g�̍ŏ��̐F��ݒ�
        /*defaultColor�̖��邳��F������minEmission�̒l�ɉ����ĕω����܂��B
     �@�@�@ * minEmission��0�ɋ߂��قǐF�͈Â��Ȃ�A1�ɋ߂��قǌ��̐F�ɋ߂��Ȃ�܂��B
     �@�@�@ * myMaterial: �ݒ肵�����}�e���A���I�u�W�F�N�g���w��
     �@�@�@ *.SetColor(): �}�e���A���̓���̐F�v���p�e�B��ݒ肷�郁�\�b�h
     �@�@�@ *"_EmissionColor"�v���p�e�B�ɐF��ݒ肷�邱�ƂŁA�I�u�W�F�N�g���̂��������Ă���悤�Ɍ����邱�Ƃ��ł���
     �@�@�@ */

        //.SetColor():(�ݒ肵�����F�̃v���p�e�B�̖��O�𕶎���Ŏw��(���C���J���[��,�ݒ肵�����F��Color�^�j
        //���C���J���[�i�{�́j�F"_Color",Color rred)���A
        //EmissionColor���I�u�W�F�N�g���̂��������Ă���悤�Ɍ�����F�̂���
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
    }

    // Update is called once per frame
    void Update()//�I�u�W�F�N�g�̌���̋�����ς��Ă���
    {

        if (this.degree >= 0)
        {
            // ���点�鋭�x���v�Z����
            //����{�F (this.defaultColor) �����ƂɁA���Ԍo�߂�Փ˂ɂ���ĕω����锭���F (emissionColor) ���v�Z
            /*olor emissionColor = ...:  emissionColor �Ƃ������O��Color�^�̕ϐ���錾���A�v�Z���ʂ������Ă��܂��B���̕ϐ����ŏI�I�Ȕ����F�ɂȂ�
      �@�@�@�@�@�@ * (...): ���ʓ��́A�����̋������v�Z���镔��
      �@�@�@�@�@�@ * this.minEmission: �����̍ŏ��l�ł��B���̒l�����邱�ƂŁA���S�Ɍ��������Ă��܂��̂�h���A��Ɉ��̖��邳��ۂ�
      �@�@�@�@�@�@ * Mathf.Deg2Rad: �p�x�����W�A���ɕϊ����܂��BMathf.Sin �֐��̓��W�A���P�ʂŊp�x���󂯎�邽�߁A�ϊ����K�v
      �@�@�@�@�@�@ * Mathf.Sin(...): �T�C���֐��ł��B�p�x�ɂ����-1����1�̊Ԃ̒l��Ԃ�
      �@�@�@�@�@�@ * * this.magEmission: magEmission �͔����̋��x�ł��B�T�C���g�̌��ʂɏ�Z���邱�ƂŁA�����̐U���𒲐����܂��BmagEmission ���傫���قǁA�����̕ω����傫���Ȃ�܂��B
      �@�@�@�@�@�@ * this.minEmission + ...: �ŏ������ʂƃT�C���g�ɂ���ĕω����锭���ʂ𑫂����킹�邱�ƂŁA�ŏI�I�Ȕ����ʂ��v�Z���܂��B
      �@�@�@�@�@�@ * this.defaultColor * ...: �Ō�ɁA��{�F (this.defaultColor) �ɁA�v�Z���ꂽ�����ʂ���Z���܂��B����ɂ��A��{�F���x�[�X�ɁA�����I�ɕω����锭���F����������܂��B
      �@�@�@�@�@�@ * this.minEmission���Q��o�Ă���Ӗ��͍ŏ���this.minEmission�Ŕ����ʂ̍ŏ��l��ݒ肵�A�I�u�W�F�N�g�����S�Ɍ��������̂�h������
      �@�@�@�@�@�@ * �Q��ڂ�this.magEmission ���悶�邱�ƂŔ����ʂ̐U���𒲐����邽��
      �@�@�@�@�@�@ * �T�C���g��-1�̂Ƃ��ł��A�����ʂ� this.minEmission - this.magEmission �ƂȂ�A0������邱�Ƃ͂Ȃ�
      �@�@�@�@�@�@ *�@*/

            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            // �G�~�b�V�����ɐF��ݒ肷��
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //���݂̊p�x������������
            //degree �̒l�����X�ɏ��������邱�ƂŁA�T�C���֐��̓��͒l��ω������A�����������I�ɕω������邽�߂ɕK�v�ȏ���
            //
            this.degree -= this.speed;
        }
    }

    //�Փˎ��ɌĂ΂��֐��i�Q�[���I�u�W�F�N�g���m���Փ˂����u�ԂɌĂяo�����j
    //�i�j�Ȃ����Փ˂Ɋւ�����
    //
    void OnCollisionEnter(Collision other)
    {
        //�p�x��180�ɐݒ�
        this.degree = 180;
    }
}