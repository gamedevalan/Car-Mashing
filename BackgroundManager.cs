using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BackgroundManager : MonoBehaviour
{
    public SpriteRenderer backgroundSkin;

    public PhotonView view;
    public static bool multiplayer;

    // Start is called before the first frame update
    void Start()
    {
        multiplayer = GameManager.privateMultiplayer;
        if (multiplayer)
        {
            view = GetComponent<PhotonView>();
            if (view.IsMine)
            {
                backgroundSkin.gameObject.GetComponent<SpriteRenderer>().sprite = ColorManager.GetBackground();
            }
        }
        else
        {
            backgroundSkin.gameObject.GetComponent<SpriteRenderer>().sprite = ColorManager.GetBackground();
        }
    }
}
