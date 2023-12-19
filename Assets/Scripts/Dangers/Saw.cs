using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Danger
{
    public GameObject[] PathNode;
    public GameObject _Saw;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector2 startPosition;
    private bool _move;


    void Start () {
        CheckNode ();
        //Debug.Log("Length: " + PathNode.Length);
    }

    void CheckNode(){
        Timer = 0;
        startPosition = _Saw.transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
        //Debug.Log("Current Node: " + CurrentNode);
    }
    void Update () {
        Timer += Time.deltaTime * MoveSpeed;
        if (_Saw.transform.position != CurrentPositionHolder) {
        _Saw.transform.position = Vector3.Lerp (startPosition, CurrentPositionHolder, Timer);
        _move = false;
    }else{
        // ОНО РАБОТААЕЕЕЕЕТ УУУРААААА (Ходит туда сюда)
        if ((CurrentNode == 0) && (_move == false)){
            CurrentNode++;
            CheckNode ();
            _move = true;
            }
        if ((CurrentNode == 1) && (_move == false)){ 
            CurrentNode--;
            CheckNode();
            _move = true;
            }
        }
    }
}
