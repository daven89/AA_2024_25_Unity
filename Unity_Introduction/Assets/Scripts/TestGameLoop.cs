using UnityEngine;

public class TestGameLoop : MonoBehaviour
{

    //private void Awake() {
    //    Debug.Log("Awake chiamta su: " + gameObject.name);
    //}

    //private void OnEnable() {
    //    Debug.Log("OnEnable chiamata su: " + gameObject.name);
    //}

    private void Start() {
        Debug.Log("Start chiamata su: " + gameObject.name);
    }

    //private void OnDisable() {
    //    Debug.Log("OnDisable chiamata su: " + gameObject.name);
    //}

    //private void OnDestroy() {
    //    Debug.Log("OnDestroy chiamata su: " + gameObject.name);
    //}

    private void FixedUpdate() {
        Debug.Log("Chiamata FixedUpdate su: " + gameObject.name); /*+ " e il fixedDeltaTime è: " + Time.fixedDeltaTime);*/
    }

    private void Update() {
        Debug.Log("Chiamata Update su: " + gameObject.name); /*+ " e il deltaTime è: " + Time.deltaTime);*/
    }

    private void LateUpdate() {
        Debug.Log("Chiamata LateUpdate su: " + gameObject.name); /*+ " e il deltaTime è: " + Time.deltaTime);*/
    }

}
