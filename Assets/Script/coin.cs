using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0,30,0) * Time.deltaTime);
    }

    
    [SerializeField]
	[Tooltip("発生させるエフェクト(パーティクル)")]
	private ParticleSystem particle;

	/// <summary>
	/// 衝突した時
	/// </summary>
	/// <param name="collision"></param>
    /// 
	private void OnTriggerEnter(Collider collision)
	{
		// 当たった相手が"Player"タグを持っていたら
        print("effect");
		if (collision.gameObject.tag == "Player")
		{
			// パーティクルシステムのインスタンスを生成する。
			ParticleSystem newParticle = Instantiate(particle);
			// 生成したパーティクルのpositionをプレイヤーと同じにする。
			newParticle.transform.position = collision.gameObject.transform.position;
			// 生成したパーティクルをプレイヤーの子オブジェクトとする。
			// newParticle.transform.parent = collision.gameObject.transform;
			// パーティクルを発生させる。
			newParticle.Play();
			// インスタンス化したパーティクルシステムのGameObjectを削除する。(任意)
			// ※第一引数をnewParticleだけにするとコンポーネントしか削除されない。
			Destroy(newParticle.gameObject, 1.0f);
		}
	}

    // private void OnCollisionEnter(Collision collision) {
    //      //当たったゲームオブジェクトがGroundタグだったとき
    //     print(collision.gameObject.tag);

    //     if (collision.gameObject.CompareTag("Coin"))
    //     {
    //         Debug.Log("地面と当たった！");
    //     }
    // }
}
