using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Moch : MonoBehaviour{
    public Vector2 ShootVec2;
    public float MochLife = 0;

    private System.Random MochMove;
    private float MochTimer = 0;
    private Transform trns;

    private GameObject MochDuply;

    void Awake() {
        trns = gameObject.transform;
    }

    void Start() {
        MochLife = 1;
        if(gameObject.CompareTag("BadMoch")) {
            StartCoroutine(BadAI());
        }

        if(gameObject.CompareTag("GoodMoch")) {
            trns.GetComponent<Rigidbody2D>().AddForce(ShootVec2 * 20000);
        }
    }
    
    void FixedUpdate() {
        if(gameObject.CompareTag("GoodMoch")) {
            MochTimer += Time.deltaTime * 1.0f;
        }

        if(MochTimer > 20.0f) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        MochDuply = collision.collider.gameObject;
        if(MochDuply.CompareTag("Player")  && gameObject.CompareTag("GoodMoch")) {
            Core.NalMoches++;
            Destroy(this.gameObject);
        };

        if(MochDuply.CompareTag("GoodMoch") && MochDuply.GetComponent<Moch>().MochLife ==1&& gameObject.CompareTag("BadMoch")) {
            MochLife--;
            MochDuply.GetComponent<Moch>().MochLife--;
            gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.blue;
            gameObject.tag = "GoodMoch";
        };
    }

    private IEnumerator BadAI() {
        MochMove = new System.Random();
        Vector2 MoveVect = new Vector2();
        float Move = 0;
        
        while(gameObject.CompareTag("BadMoch")) {
            switch(MochMove.Next(2)) {
                case 0:
                    MoveVect = Vector2.right;
                    break;
                case 1:
                    MoveVect = Vector2.left;
                    break;
            }

            Move = MochMove.Next(200,800);
            trns.GetComponent<Rigidbody2D>().AddForce(MoveVect * Move ,ForceMode2D.Impulse);
            yield return new WaitForSeconds(6.0f);
        }
    }
}
