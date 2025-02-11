using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{

    //最小サイズ
    private float minimum = 1.0f;
    //拡大縮小スピード
    private float magSpeed = 10.0f;
    //拡大率
    private float magnification = 0.07f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        /* ★プログラムの解説★
         *  this.transform.localScale = new Vector3(）：ゲームオブジェクトのスケール（大きさ）を変更するもので（）内に変更内容を書く
         *  ↑※（）内はX,Y,Z軸を書く
         *  Y軸： transform.localScale.yは Y軸方向のスケールはそのまま　という意味
         *  Mathf.Sin()：角度を入力すると、-1 から 1 までの値を返す（）内が角度※ラジアン単位しか使えない
         *  角度が0度のとき、サイン関数の値は0です。
　　　　　　角度が90度（π/2ラジアン）のとき、サイン関数の値は1です。
　　　　　　角度が180度（πラジアン）のとき、サイン関数の値は0です。
　　　　　　角度が270度（3π/2ラジアン）のとき、サイン関数の値は-1です。
　　　　　　角度が360度（2πラジアン）のとき、サイン関数の値は0に戻ります。
         * Time.time：経過時間（秒単位）、this.magSpeedは速さ（ime.time * this.magSpeed：時間とともに変化する角度）
         * サイン波が 1 のとき、式の値は minimum + this.magnification となり、最大値になります。
　　　　　 サイン波が -1 のとき、式の値は minimum - this.magnification となり、最小値になります。
         */


        /*transform.localScale= new Vector3()=ゲームオブジェクトのスケール（大きさ）を変更する
   　　　　* localScaleはscaleと違い、親オブジェクトのスケールが変更されると、子オブジェクトのlocalScaleも影響を受ける（スケールは影響を受けない）
   　　　　*new Vector3(): 新しい3次元ベクトル（Vector3）を作成 X、Y、Zの各軸方向のスケール値を指定するために使用
   　　　　*★使い方★
   　　　　*transform.localScale = new Vector3(x, y, z);
  　　　　　x: X軸方向のスケール値
  　　　　　y: Y軸方向のスケール値
  　　　　　z: Z軸方向のスケール値
      　　* オブジェクトをX軸方向に2倍、Y軸方向に0.5倍、Z軸方向に1倍にする
  　　　　　transform.localScale = new Vector3(2, 0.5f, 1);
        　*オブジェクトを等倍にする（元の大きさに戻す）
  　　　　　transform.localScale = Vector3.one; // Vector3.one は new Vector3(1, 1, 1) と同じ
          *解説
      　　 *スケール値が1の場合、オブジェクトは元の大きさです。
  　　　　　スケール値が1より大きい場合、オブジェクトは拡大されます。
  　　　　　スケール値が1より小さい場合、オブジェクトは縮小されます。
  　　　　　スケール値に0を指定すると、オブジェクトはその軸方向のサイズが0になり、見えなくなります。
            スケール値に負の値を指定すると、オブジェクトは反転します。
           */
      this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
    }
}
