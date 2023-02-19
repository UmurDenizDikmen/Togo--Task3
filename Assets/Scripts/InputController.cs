using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour,IDragHandler
{
    private float mouseSense = 175f;
    public Transform CurrentPlayer;
    public void OnDrag(PointerEventData eventData)
    {
       
        

            Vector3 Currentpos =CurrentPlayer.position;
            Currentpos.x = Mathf.Clamp(Currentpos.x + (eventData.delta.x / mouseSense), -7, 7);
        CurrentPlayer.position = new Vector3(Currentpos.x, CurrentPlayer.position.y, CurrentPlayer.position.z);

        


    }
}