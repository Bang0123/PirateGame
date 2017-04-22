using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class IsleCollider : MonoBehaviour
{

    public string Text;
    private Rigidbody2D _rigidbody2D;
    //private bool showText = false, someRandomCondition = true;
    private float currentTime = 0.1f, executedTime = 0.1f, timeToWait = 0.0f;
    public int Gold;


    // Use this for initialization
    void Start()
    {
        Gold = 10;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // TODO Gold need a remake, each island has its own gold counter which is not gut :(!
    // Update is called once per frame
    void Update()
    {

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
        if (col.gameObject.tag == "Player")
        {
            var playerobj = col.gameObject.GetComponent<PlayerController>();
            //GUI.Label(new Rect(0, 0, 100, 100), "Some Random Text");
            Debug.Log("Player robbed me xd");
            playerobj.AddGold(Gold);
            playerobj.UpdateGoldCounter();
        }
        if (col.gameObject.tag == "CannonBall")
        {
            var playerobj = col.gameObject.GetComponent<BallController>().Parent;
            Debug.Log("Player Shot me xd");
            if (playerobj != null)
            {
                playerobj.AddGold(Gold);
                playerobj.UpdateGoldCounter();
            }
        }





    }
}
