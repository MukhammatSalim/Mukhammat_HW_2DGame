using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelFinish : MonoBehaviour
{
    public UnityEvent Act;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other) {
        Act?.Invoke();
    }
}
