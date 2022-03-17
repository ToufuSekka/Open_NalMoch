using UnityEngine;

public class CameraView : MonoBehaviour{
    private GameObject Nals;

    void Start() {
        Nals = GameObject.Find("Nal");
    }

    void LateUpdate() {
        gameObject.transform.position = new Vector3(Nals.transform.position.x,0,-10);
    }
}
