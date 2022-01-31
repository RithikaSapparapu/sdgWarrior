using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public QuestionUIScript QuestionUIScript;
    public EndUIScript EndUIScript;
    
    /*public static int getRandom()
    {
        Random rnd = new Random();
        return rnd.Next(2);
    }*/

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit something");
        Debug.Log(col.gameObject.name);

        string temp1 = col.gameObject.name;
        string temp2 = "";
        if(temp1.Length>=7){
            for(int i=0; i<7; i++){
                temp2 += temp1[i];
            }
        }

        if (temp2 == "Crystal"){
            QuestionUIScript.SetUp();
        }
        else if(temp2 == "FinalCrystal"){
            EndUIScript.SetUp();
        }

        if (temp2 == "Crystal"){
            Destroy(col.gameObject);
        }
    }
}
