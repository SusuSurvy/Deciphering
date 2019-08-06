using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour {
    bool isPlayAnim = false;
    public Animation animation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if(hit.collider != null)
            {
                print(hit.collider.gameObject.name);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                if(hit.collider.gameObject.name == "key")
                {
                    isPlayAnim = true;
                    print("iskey"); 
                }

            }

        }



        if (isPlayAnim)
        {
            animation.Play("KeyMove2");
            isPlayAnim = false;
            print("bofang");
        }
	}
}
