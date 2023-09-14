using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D jer;
    Rigidbody2D tom;
    Vector2 rightInitial;
    Vector2 leftInitial;
    public float displacement;
    public string playerTag;
    void Start() {
        jer = GetComponent<Rigidbody2D>();
        tom = GetComponent<Rigidbody2D>();
        rightInitial = jer.transform.position;
        leftInitial = tom.transform.position;
        displacement = 0.015f;
    }

    void Update(){
        playerTag = gameObject.tag;
        if (gameObject.CompareTag(playerTag)){
            if (playerTag == "jerry"){
                if ((Input.GetKey(KeyCode.UpArrow)) && rightInitial.y < 3.68) {
                    rightInitial.y = rightInitial.y + displacement;
                    jer.MovePosition(rightInitial);
                } else if ((Input.GetKey(KeyCode.DownArrow)) && rightInitial.y > -2.7) {
                    rightInitial.y = rightInitial.y - displacement;
                    jer.MovePosition(rightInitial);
                }
            }
        } if (gameObject.CompareTag(playerTag)){
            if (playerTag == "tom"){
                if ((Input.GetKey ("w")) && leftInitial.y < 3.68) {
                    leftInitial.y = leftInitial.y + displacement;
                    tom.MovePosition(leftInitial);
                } else if ((Input.GetKey ("s")) && leftInitial.y > -2.7) {
                    leftInitial.y = leftInitial.y - displacement;
                    tom.MovePosition(leftInitial);
                }
            }
        }
    }
}