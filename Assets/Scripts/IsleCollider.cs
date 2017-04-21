using UnityEngine;
using UnityEngine.UI;

public class IsleCollider : MonoBehaviour {

    public string Text;
    private Rigidbody2D _rigidbody2D;
    //private bool showText = false, someRandomCondition = true;
    private float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 0.0f;
    private int gold = 0;
    // Use this for initialization
    void Start () {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // TODO Gold need a remake, each island has its own gold counter which is not gut :(!
    public int Gold
    {
        get { return gold; }
    }
    // Update is called once per frame
    void Update () {

        //currentTime = Time.time;
        //if (someRandomCondition)
        //    showText = true;
        //else
        //    showText = false;

        //if (executedTime != 0.0f)
        //{
        //    if (currentTime - executedTime > timeToWait)
        //    {
        //        executedTime = 0.0f;
        //        someRandomCondition = false;
        //    }
        //}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "showText")
        //GUI.Label(new Rect(0, 0, 100, 100), "Some Random Text");
        Debug.Log("Collision with isle");
        gold++;
        GameObject.FindGameObjectWithTag("Gold").GetComponent<Text>().text = "" + gold;
        Debug.Log("Gold +1");




    }
}
