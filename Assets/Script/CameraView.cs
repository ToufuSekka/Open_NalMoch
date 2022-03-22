using UnityEngine;
using TMPro;

public class CameraView : MonoBehaviour{
    private GameObject Nals;
    private TextMeshProUGUI MochTasks, NalLifes;

    void Start() {
        MochTasks = gameObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        NalLifes = gameObject.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        Nals = GameObject.Find("Nal");
    }

    void Update() {
        MochTasks.text = "<u><b>Mochies</b></u> : "+Core.NalMoches.ToString();
        NalLifes.text = "<u>Lifes</u> : " + Core.NalLifes.ToString();
    }

    void LateUpdate() {
        gameObject.transform.position = new Vector3(Nals.transform.position.x,0,-10);
    }
}