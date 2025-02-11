using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g�����锠�umyHingeJoint�v
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾�umyHingeJoint�v�̔��ɃR���|�[�l���g�uHingeJoint�v������
        this.myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
�@�@�@�@/*SetAngle(...): ���̕����́ASetAngle �Ƃ������O�̊֐����Ăяo���֐��i�I�u�W�F�N�g�̉�]��p�x��ݒ肷������j
 �@�@�@�@* ����̏�Ԃ�ݒ肷��B�i�j�Ȃ����p�x�̎w��
 �@�@�@�@*/
�@�@�@�@SetAngle(this.defaultAngle);

�@�@}

// Update is called once per frame
void Update()
{

        //�����L�[�������������t���b�p�[�𓮂���
        /*�u&&�v�����̈Ӗ�
         * tag == "LeftFripperTag"�I�u�W�F�N�g�̃^�O�� "LeftFripperTag" �ł���
         * �S�̂�ʂ��āu�����L�[��������A���I�u�W�F�N�g�̃^�O�� "LeftFripperTag" �ł���ꍇ�v�ɂȂ�
         */
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag" || Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
        {
            //�p�x�̎w��
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag" || Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //���L�[�����ꂽ���t���b�p�[�����ɖ߂�
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag" || Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag" || Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyDown(KeyCode.S) && (tag == "LeftFripperTag" || tag == "RightFripperTag") || Input.GetKeyDown(KeyCode.DownArrow) && (tag == "LeftFripperTag" || tag == "RightFripperTag"))
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.S) && (tag == "LeftFripperTag" || tag == "RightFripperTag") || Input.GetKeyUp(KeyCode.DownArrow) && (tag == "LeftFripperTag" || tag == "RightFripperTag"))
        {
            SetAngle(this.defaultAngle);
        }
       

    }

    //�t���b�p�[�̌X����ݒ�
    //SetAngle(float angle)��SetAngle�Ƃ����֐���float�^��angle�͓x���@�i�x�j�̒P��
    public void SetAngle(float angle)//angle�͐ݒ肵�����x���@�̊p�x��\���ϐ�
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        /*���ϐ��̏����菇
         * this.myHingeJoint: ���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g��HingeJoint�R���|�[�l���g���擾
         * .spring: HingeJoint�R���|�[�l���g�� spring �v���p�e�B�ɃA�N�Z�X
         * JointSpring spring = ...: �擾���� spring �v���p�e�B�̒l���AJointSpring�^�iHingeJoint�R���|�[�l���g�̃o�l�̓������ꎞ�I�ɕۑ��j�̕ϐ� spring �ɃR�s�[
         * ��HingJoint�͂�����Ȃ��̂ŕϐ��ɃR�s�[���邱�ƂŕύX���\�ɂȂ�
         */
        jointSpr.targetPosition = angle;
        /*���ϐ���.targetPosition = �̓o�l���ڕW�Ƃ���p�x�i�x���@�j��ݒ肷��v���O����
         */
        this.myHingeJoint.spring = jointSpr;
        //�ύX�������� spring �ϐ��̒l���AHingeJoint�R���|�[�l���g�� spring �v���p�e�B�ɍēx���

    }
}