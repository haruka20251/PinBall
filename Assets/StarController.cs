using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StarController : MonoBehaviour
{
    // 回転速度(小数の変数）
    private float rotSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //回転開始時のオブジェクトの角度（軸の回転角度のこと）の設定(randomに設定することで複数の★がばらばらに回転開始するように設定）
        //0=回転なし数字があるところが回転軸＝回転する角度が入っているかどうか

        /*回転を開始する角度を設定
         *  Rotate メソッドは、ゲームオブジェクトを指定された角度だけ回転させます。
         *  Random.Range(0, 360)=0以上360未満の範囲でランダムな整数を生成する
         *  コードの意味↓
         *  Random: Randomクラスは、疑似乱数を生成するための機能を提供します。
         *  Range: Rangeメソッドは、指定された範囲内でランダムな値を生成します。
         *  0: 乱数の最小値（この値を含む）。
         *　360: 乱数の最大値（この値を含まない）。
         */
        this.transform.Rotate(0, Random.Range(0, 360), 0);

    }

    // Update is called once per frame
    void Update()
    {
        /*回転
         *「Rotate」関数は現在の角度から引数に与えた角度のぶんだけ回転する関数
         *補足↓
         *Rotate メソッドには、回転軸と角度を指定するいくつかのオーバーロードがあります。
         *回転軸は、Vector3値で指定します。例えば、(0, 1, 0) はY軸を表します。
         *角度は、度単位で指定します。
         */

        this.transform.Rotate(0, this.rotSpeed, 0);
    }
}
