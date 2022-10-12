using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    doorScript script;
    Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        door.TryGetComponent<doorScript>(out script);
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRelease()
    {
        if ((transform.eulerAngles.x > 100) && script != null)
        {
            script.OnSelect();
        }
        rigid.velocity = Vector3.zero;
    }
}
