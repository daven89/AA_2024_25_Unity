using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eserizio1 : MonoBehaviour
{
    [SerializeField]
    private GameObject obj1;
    [SerializeField]
    private GameObject obj2;
    [SerializeField]
    private GameObject obj3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            obj1.SetActive(!obj1.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            obj2.SetActive(!obj2.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            obj3.SetActive(!obj3.activeSelf);
        }
    }
}
