using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる箱「myHingeJoint」
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Start is called before the first frame update
    void Start()
    {
        //HingeJointコンポーネント取得「myHingeJoint」の箱にコンポーネント「HingeJoint」を入れる
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
　　　　/*SetAngle(...): この部分は、SetAngle という名前の関数を呼び出す関数（オブジェクトの回転や角度を設定する役割）
 　　　　* 特定の状態を設定する。（）ないが角度の指定
 　　　　*/
　　　　SetAngle(this.defaultAngle);

　　}

// Update is called once per frame
void Update()
{

        //左矢印キーを押した時左フリッパーを動かす
        /*「&&」＝且つの意味
         * tag == "LeftFripperTag"オブジェクトのタグが "LeftFripperTag" である
         * 全体を通して「左矢印キーが押され、かつオブジェクトのタグが "LeftFripperTag" である場合」になる
         */
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag" || Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
        {
            //角度の指定
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag" || Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
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

    //フリッパーの傾きを設定
    //SetAngle(float angle)＝SetAngleという関数でfloat型でangleは度数法（度）の単位
    public void SetAngle(float angle)//angleは設定したい度数法の角度を表す変数
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        /*↑変数の処理手順
         * this.myHingeJoint: このスクリプトがアタッチされているゲームオブジェクトのHingeJointコンポーネントを取得
         * .spring: HingeJointコンポーネントの spring プロパティにアクセス
         * JointSpring spring = ...: 取得した spring プロパティの値を、JointSpring型（HingeJointコンポーネントのバネの特性を一時的に保存）の変数 spring にコピー
         * ※HingJointはいじれないので変数にコピーすることで変更が可能になる
         */
        jointSpr.targetPosition = angle;
        /*↑変数名.targetPosition = はバネが目標とする角度（度数法）を設定するプログラム
         */
        this.myHingeJoint.spring = jointSpr;
        //変更を加えた spring 変数の値を、HingeJointコンポーネントの spring プロパティに再度代入

    }
}