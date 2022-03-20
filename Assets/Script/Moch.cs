using System.Collections;
using UnityEngine;

public class Moch : MonoBehaviour{
    public Vector2 ShootVec2;

    private Transform trns;
    void Awake() {
        trns = gameObject.transform;
    }
    void Start() {
        trns.GetComponent<Rigidbody2D>().AddForce(ShootVec2* 20000);
        Debug.Log(ShootVec2);
        StartCoroutine(Death());
    }

    IEnumerator Death() {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
        yield break;
    }
}
