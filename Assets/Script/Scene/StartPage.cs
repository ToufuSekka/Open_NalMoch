using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartPage : MonoBehaviour{

    Button BTN;
    void Start() {
        BTN = gameObject.transform.GetChild(0).GetComponent<Button>();

        BTN.onClick.AddListener(delegate {
            SceneManager.LoadScene("StartGame");
        });
    }
}
