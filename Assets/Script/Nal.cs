using UnityEngine;

public class Nal : MonoBehaviour{
    private GameObject Moches;
    private Vector3 Force;

    void Start(){
        Core.NalLifes = 20;
        Core.NalMoches = 10;
    }

    void Update() {
        if(Core.NalLifes == 0)
            Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Moches = collision.collider.gameObject;

        if(Moches.CompareTag("BadMoch")) {
            Force = gameObject.transform.position - Moches.transform.position;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Force.normalized * 7000, ForceMode2D.Impulse);
            Core.NalLifes--;
        };
    }
}