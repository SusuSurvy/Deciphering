using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour {
    bool isPlayAnim = false;
    public Animation animation;
    public GameObject all;
    public GameObject start;
    public GameObject main;
    public GameObject page_under;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;
    public GameObject page8;
    public GameObject page0;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject page1_memory;
    public GameObject page2_memory;
    public GameObject page3A_memory;
    public GameObject page3B_memory;
    public GameObject page4_memory;
    public GameObject page5_memory;
    public GameObject page6_memory;
    public GameObject page7_memory;
    public GameObject page8_memory;
    // Use this for initialization
    void Start () {
        main.gameObject.SetActive(false);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(false);
        page4.gameObject.SetActive(false);
        page5.gameObject.SetActive(false);
        page6.gameObject.SetActive(false);
        page7.gameObject.SetActive(false);
        page8.gameObject.SetActive(false);
        page_under.gameObject.SetActive(false);
        
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button3.gameObject.SetActive(false);
        page1_memory.gameObject.SetActive(false);
        page2_memory.gameObject.SetActive(false);
        page3A_memory.gameObject.SetActive(false);
        page3B_memory.gameObject.SetActive(false);
        page4_memory.gameObject.SetActive(false);
        page5_memory.gameObject.SetActive(false);
        page6_memory.gameObject.SetActive(false);
        page7_memory.gameObject.SetActive(false);
        page8_memory.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                if (hit.collider.gameObject.name == "start")
                {
                    isPlayAnim = true;
                    print("is_book_close");
                }

            }

        }



        if (isPlayAnim)
        {
            animation.Play("close_open");
            page2.gameObject.SetActive(true);
            page3.gameObject.SetActive(true);
            page4.gameObject.SetActive(true);
            page5.gameObject.SetActive(true);
            page6.gameObject.SetActive(true);
            page7.gameObject.SetActive(true);
            page8.gameObject.SetActive(true);

            isPlayAnim = false;
            print("bofang");
            GameObject.Destroy(start, 0);
            GameObject.Destroy(all, 1.5f);
            Invoke("BookComeBack", 0.8f);

           
        }
    }

    private void BookComeBack2()
    {
        print("after 2s");
    }

    private void BookComeBack()
    {
        main.gameObject.SetActive(true);
        page0.gameObject.SetActive(true);
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
        page1_memory.gameObject.SetActive(true);
        print("after 2sec");
    }

    IEnumerator mainActive()
    {
        yield return new WaitForSeconds(2.0f);
        print("after 2s");
        main.gameObject.SetActive(true);
        
    }
}
