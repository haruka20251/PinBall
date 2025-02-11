using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    //マテリアルを入れる箱
    Material myMaterial;
    //Emissionの最小値の明るさ(Emission:光を放出する効果)
    private float minEmission = 0.2f;
    //Emissionの強度（magEmission ：明るさの強さ）
    private float magEmission = 2.0f;
    //角度（仮想的な角度）
    //サイン関数を使って周期的な変化を作るために、角度が必要だが、
    //オブジェクトの実際の回転角度を使う必要はないので仮想的な角度を使う
    private int degree = 0;
    //発光速度
    private int speed = 5;

    /* ターゲットのデフォルトの色
     * Color: Unityで色を扱うためのデータ型
     * defaultColor: 変数名
     * Color.white: Unityに定義されている白色を表す定数
     * ゲームオブジェクトやUI要素などの色を初期化する際に、デフォルトの色として白を設定するために使用
     */
    Color defaultColor = Color.white;

    // Start is called before the first frame update
    void Start()//Start関数でターゲットが何色に光るかを決める
    {

        // タグによって光らせる色を変える
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

        //オブジェクトにアタッチしているMaterialを取得
        this.myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        /*defaultColorの明るさや色合いがminEmissionの値に応じて変化します。
     　　　 * minEmissionが0に近いほど色は暗くなり、1に近いほど元の色に近くなります。
     　　　 * myMaterial: 設定したいマテリアルオブジェクトを指定
     　　　 *.SetColor(): マテリアルの特定の色プロパティを設定するメソッド
     　　　 *"_EmissionColor"プロパティに色を設定することで、オブジェクト自体が発光しているように見せることができる
     　　　 */

        //.SetColor():(設定したい色のプロパティの名前を文字列で指定(メインカラー等,設定したい色をColor型）
        //メインカラー（本体）："_Color",Color rred)等、
        //EmissionColor＝オブジェクト自体が発光しているように見える色のこと
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);
    }

    // Update is called once per frame
    void Update()//オブジェクトの光りの強さを変えていく
    {

        if (this.degree >= 0)
        {
            // 光らせる強度を計算する
            //↑基本色 (this.defaultColor) をもとに、時間経過や衝突によって変化する発光色 (emissionColor) を計算
            /*olor emissionColor = ...:  emissionColor という名前のColor型の変数を宣言し、計算結果を代入しています。この変数が最終的な発光色になる
      　　　　　　 * (...): 括弧内は、発光の強さを計算する部分
      　　　　　　 * this.minEmission: 発光の最小値です。この値があることで、完全に光が消えてしまうのを防ぎ、常に一定の明るさを保つ
      　　　　　　 * Mathf.Deg2Rad: 角度をラジアンに変換します。Mathf.Sin 関数はラジアン単位で角度を受け取るため、変換が必要
      　　　　　　 * Mathf.Sin(...): サイン関数です。角度によって-1から1の間の値を返す
      　　　　　　 * * this.magEmission: magEmission は発光の強度です。サイン波の結果に乗算することで、発光の振幅を調整します。magEmission が大きいほど、発光の変化が大きくなります。
      　　　　　　 * this.minEmission + ...: 最小発光量とサイン波によって変化する発光量を足し合わせることで、最終的な発光量を計算します。
      　　　　　　 * this.defaultColor * ...: 最後に、基本色 (this.defaultColor) に、計算された発光量を乗算します。これにより、基本色をベースに、周期的に変化する発光色が生成されます。
      　　　　　　 * this.minEmissionが２回出てくる意味は最初のthis.minEmissionで発光量の最小値を設定し、オブジェクトが完全に光を失うのを防ぐため
      　　　　　　 * ２回目はthis.magEmission を乗じることで発光量の振幅を調整するため
      　　　　　　 * サイン波が-1のときでも、発光量は this.minEmission - this.magEmission となり、0を下回ることはない
      　　　　　　 *　*/

            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            //degree の値を徐々に小さくすることで、サイン関数の入力値を変化させ、発光を周期的に変化させるために必要な処理
            //
            this.degree -= this.speed;
        }
    }

    //衝突時に呼ばれる関数（ゲームオブジェクト同士が衝突した瞬間に呼び出される）
    //（）ないが衝突に関する情報
    //
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;
    }
}