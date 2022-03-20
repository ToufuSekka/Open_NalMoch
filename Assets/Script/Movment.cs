using UnityEngine;

public class Movment : MonoBehaviour{

    public bool Juming = false;
    void FixedUpdate(){
        if(Input.GetKey(KeyCode.A)) {
            gameObject.transform.rotation = Quaternion.Euler(0, 180,0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 4550);
        }

        if(Input.GetKey(KeyCode.S)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 18200);
        }

        if(Input.GetKey(KeyCode.D)) {
            gameObject.transform.rotation= Quaternion.Euler(0, 0, 0);
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 4550);
        }

        if(Input.GetKey(KeyCode.Space) && !Juming) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 9100, ForceMode2D.Impulse);
            Juming = true;
        }
    }

    void OnCollisionEnter2D(Collision2D Cod2d) {
        if(Cod2d.gameObject.tag.Equals("Ground")) {
            Juming = false;
        }
    }
}
