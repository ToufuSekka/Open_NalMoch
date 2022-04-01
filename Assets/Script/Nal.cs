using UnityEngine;

public class Nal : MonoBehaviour{
    private GameObject Moches;
    private Vector3 Force;
    
    void Awake() {
        gameObject.AddComponent<Status>();
        gameObject.AddComponent<Movment>();
        gameObject.AddComponent<Attack>();
    }

    void Start(){
        GetComponent<Status>().Life = 20;
        GetComponent<Status>().Armor = 0;
        GetComponent<Status>().Damage = 0;
        GetComponent<Status>().SpecStat.Add("Moches", 10);
    }

    void Update() {
        if(GetComponent<Status>().Life < 1)
            Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Moches = collision.collider.gameObject;

        if(Moches.CompareTag("GoodMoch")) {
            GetComponent<Status>().SpecStat["Moches"] += 1;
        };

        if(Moches.CompareTag("BadMoch")) {
            Force = gameObject.transform.position - Moches.transform.position;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Force.normalized * 7000, ForceMode2D.Impulse);
            GetComponent<Status>().Life -= Moches.GetComponent<Status>().Damage;
        };
    }
}