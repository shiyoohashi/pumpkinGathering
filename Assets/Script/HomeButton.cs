using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ライブラリの追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeButton : MonoBehaviour {	
    // 始まった時に実行する関数	
    void Start () {
        print("GoHomeStart");
        // ボタンが押された時、StartGame関数を実行 
        gameObject.GetComponent<Button>().onClick.AddListener(GoHome);
    } // StartGame関数 
    void GoHome() {
        // GameSceneをロード 
        SceneManager.LoadScene("StartScene");
    }
}
