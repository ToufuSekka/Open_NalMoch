using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour{
    private GameObject BadMoch, Duply, Nal;
    private Transform MochTrans;
    private System.Random ran, PosRan;
    private int Dices, PosDices;

    public static int NalLifes = 0;
    public static int NalMoches = 0;

    void Awake() {
        BadMoch = Resources.Load<GameObject>("T");
        Nal = GameObject.Find("Nal");
        MochTrans = gameObject.transform;
        ran = new System.Random();
        PosRan = new System.Random();
    }

    void Start(){
        //StartCoroutine(NalStat());
    }

    void Update(){
        NalLifes = Nal.gameObject.GetComponent<Status>().Life;
        NalMoches = Nal.gameObject.GetComponent<Status>().SpecStat["Moches"];

        Dices = ran.Next(1000);

        if(!Nal.gameObject) {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif

        }

        if(Dices > 998) {
            PosDices = PosRan.Next(3700) - 400;
            Duply = Instantiate(BadMoch, MochTrans.transform.position + (new Vector3(PosDices,-190,0)), Quaternion.identity, MochTrans);
            Duply.transform.GetChild(0).GetComponent<Image>().color = Color.red;
            Duply.tag = "BadMoch";
        }
    }
    /*
    private IEnumerator NalStat() {
        NalLifes = Nal.gameObject.GetComponent<Status>().Life;
        NalMoches = Nal.gameObject.GetComponent<Status>().SpecStat["Moches"];
        yield return new WaitForSeconds(0.1f);
    }
*/
}
