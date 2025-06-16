using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLog : MonoBehaviour
{

    [SerializeField]
    private int mouseButtonIndex;

    private BoxCollider2D bc;

    public int MouseButtonIndex {
        get { return mouseButtonIndex; }
    }


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Log normale");
        //Debug.LogWarning("Log warning");
        //Debug.LogError("Log error");
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(mouseButtonIndex)) {
            bc.enabled = !bc.enabled;
        }
    }

}
