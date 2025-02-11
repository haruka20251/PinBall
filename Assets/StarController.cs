using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StarController : MonoBehaviour
{
    // ��]���x(�����̕ϐ��j
    private float rotSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //��]�J�n���̃I�u�W�F�N�g�̊p�x�i���̉�]�p�x�̂��Ɓj�̐ݒ�(random�ɐݒ肷�邱�Ƃŕ����́����΂�΂�ɉ�]�J�n����悤�ɐݒ�j
        //0=��]�Ȃ�����������Ƃ��낪��]������]����p�x�������Ă��邩�ǂ���

        /*��]���J�n����p�x��ݒ�
         *  Rotate ���\�b�h�́A�Q�[���I�u�W�F�N�g���w�肳�ꂽ�p�x������]�����܂��B
         *  Random.Range(0, 360)=0�ȏ�360�����͈̔͂Ń����_���Ȑ����𐶐�����
         *  �R�[�h�̈Ӗ���
         *  Random: Random�N���X�́A�^�������𐶐����邽�߂̋@�\��񋟂��܂��B
         *  Range: Range���\�b�h�́A�w�肳�ꂽ�͈͓��Ń����_���Ȓl�𐶐����܂��B
         *  0: �����̍ŏ��l�i���̒l���܂ށj�B
         *�@360: �����̍ő�l�i���̒l���܂܂Ȃ��j�B
         */
        this.transform.Rotate(0, Random.Range(0, 360), 0);

    }

    // Update is called once per frame
    void Update()
    {
        /*��]
         *�uRotate�v�֐��͌��݂̊p�x��������ɗ^�����p�x�̂Ԃ񂾂���]����֐�
         *�⑫��
         *Rotate ���\�b�h�ɂ́A��]���Ɗp�x���w�肷�邢�����̃I�[�o�[���[�h������܂��B
         *��]���́AVector3�l�Ŏw�肵�܂��B�Ⴆ�΁A(0, 1, 0) ��Y����\���܂��B
         *�p�x�́A�x�P�ʂŎw�肵�܂��B
         */

        this.transform.Rotate(0, this.rotSpeed, 0);
    }
}
