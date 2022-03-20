using UnityEngine;

public class Attack : MonoBehaviour{

    private GameObject Tester, Dpl;
    private Vector2 Mouse, NalPos, Finale, F_Nmr;
    private Transform OriPos;

    void Start() {
        Tester = Resources.Load<GameObject>("T");
        OriPos = gameObject.transform;
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)) {
            //GetVector2
            Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            NalPos = gameObject.transform.position;
            Finale = Mouse - NalPos;
            F_Nmr = Finale.normalized;
            if(F_Nmr.x < 0) {
                Dpl = Instantiate(Tester, OriPos.position + (Vector3.left * 15.0f), Quaternion.identity);
            } else if(F_Nmr.x > 0) {
                Dpl = Instantiate(Tester, OriPos.position + (Vector3.right * 15.0f), Quaternion.identity);
            }

            Dpl.GetComponent<Moch>().ShootVec2 = F_Nmr;
        }
    }
}
