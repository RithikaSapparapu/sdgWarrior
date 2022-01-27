using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public QuestionUIScript QuestionUIScript;
    
    /*public static int getRandom()
    {
        Random rnd = new Random();
        return rnd.Next(2);
    }*/

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit something");
        Debug.Log(col.gameObject.name);
        if (col.gameObject.name != "DestructibleBox_stepOn"){
            QuestionUIScript.SetUp();
        }
        if (col.gameObject.name == "Crystal"){
            Destroy(col.gameObject);
        }
    }
}
