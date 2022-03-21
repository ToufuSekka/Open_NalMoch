using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour{
    private GameObject BadMoch, Duply;
    private Transform MochTrans;
    private System.Random ran, PosRan;
    private int Dices, PosDices;

    public static int NalLifes = 20;
    public static int NalMoches = 10;

    void Start(){
        BadMoch = Resources.Load<GameObject>("T");
        MochTrans = gameObject.transform;
        ran = new System.Random();
        PosRan = new System.Random();
    }

    void Update(){
        Dices = ran.Next(1000);
        
        if(Dices > 996) {
            PosDices = PosRan.Next(3700) - 400;
            Duply = Instantiate(BadMoch, MochTrans.transform.position + (new Vector3(PosDices,-190,0)), Quaternion.identity, MochTrans);
            Duply.transform.GetChild(0).GetComponent<Image>().color = Color.red;
            Duply.tag = "BadMoch";
        }
    }
}
