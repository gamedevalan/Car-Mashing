using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LookAt : MonoBehaviour
{
    public static Transform node;
    public int speed;
    public PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if multiplayer so that view.IsMine doesn't cause an error.
        if (Car_Movement.multiplayer) {
            if (view.IsMine)
            {
                LookAtNode();
            }
        }
        else
        {
            LookAtNode();
        }
    }

    void LookAtNode()
    {
        Vector2 direction = node.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
