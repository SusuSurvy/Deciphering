using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour {
    bool isPlayAnim = false;
    bool isSelect = false;
    int pageNum = 1;
    int pageSelect = 0;
    public Animation animation;
    public GameObject page_under;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public GameObject page4;
    public GameObject page5;
    public GameObject page6;
    public GameObject page7;
    public GameObject page8;
    public GameObject page9;
    public GameObject page10;
    public GameObject page11;
    public GameObject page12;
    public GameObject page13;
    public GameObject page14;
    public GameObject page15;
    public GameObject button_down;
    public GameObject button_down2;
    public GameObject button_down3;
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
        page1.gameObject.SetActive(false);
        page2.gameObject.SetActive(false);
        page3.gameObject.SetActive(false);
        page4.gameObject.SetActive(false);
        page5.gameObject.SetActive(false);
        page6.gameObject.SetActive(false);
        page7.gameObject.SetActive(false);
        page8.gameObject.SetActive(false);
        page9.gameObject.SetActive(false);
        page10.gameObject.SetActive(false);
        page11.gameObject.SetActive(false);
        page12.gameObject.SetActive(false);
        page13.gameObject.SetActive(false);
        page14.gameObject.SetActive(false);
        page15.gameObject.SetActive(false);
        page_under.gameObject.SetActive(false);

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
                if (hit.collider.gameObject.name == "next_page")
                {
                    
                    isPlayAnim = true;
                    print("is_next_page");
                }

            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                if (hit.collider.gameObject.name == "secelt_city")
                {

                    isSelect = true;
                    print("secelt_city");
                    pageSelect = 1;
                }

            }

        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                print(hit.collider.gameObject.name);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                if (hit.collider.gameObject.name == "secelt_village")
                {

                    isSelect = true;
                    print("secelt_village");
                    pageSelect = 2;
                }

            }

        }

        if (isSelect)
        {
            animation.Play("page");
            isSelect = false;
            pageNum++;
            print("翻页_选择");

            if (pageSelect == 1)
            {
                page2_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page3A", 1.5f);

            }


            if (pageSelect == 2)
            {
                page2_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page3B", 1.5f);

            }

        }


        if (isPlayAnim)
        {


            animation.Play("page");
            isPlayAnim = false;
            
            pageNum++;
            print("翻页" );
            if (pageNum == 1)
            {
                Invoke("NowPage", 1.5f);
                
            }

            if (pageNum == 2)
            {
                page1_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page2", 1.5f);

            }

            if (pageNum == 3)
            {
                //page2_memory.gameObject.SetActive(false);
                //Invoke("NowPage", 1.5f);
                //Invoke("Page3", 1.5f);
            }

            if (pageNum == 4)
            {

                page3A_memory.gameObject.SetActive(false);
                page3B_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page4", 1.5f);
            }

            if (pageNum == 5)
            {
                page4_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page5", 1.5f);
            }

            if (pageNum == 6)
            {
                page5_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page6", 1.5f);
            }

            if (pageNum == 7)
            {
                page6_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page7", 1.5f);
            }

            if (pageNum == 8)
            {
                page7_memory.gameObject.SetActive(false);
                Invoke("NowPage", 1.5f);
                Invoke("Page8", 1.5f);
                Destroy(button_down, 1.5f);
                Destroy(button_down2, 1.5f);
                Destroy(button_down3, 1.5f);
            }
        }




    }

    public void NowPage()
    {
        print("现在是第"+ pageNum + "页");
    }



    public void Page2()
    {
        page2_memory.gameObject.SetActive(true);
        button_down.gameObject.SetActive(false);
        button_down2.gameObject.SetActive(false);
        button_down3.gameObject.SetActive(false);
    }

    public void Page3A()
    {
        page3A_memory.gameObject.SetActive(true);
        button_down.gameObject.SetActive(true);
        button_down2.gameObject.SetActive(true);
        button_down3.gameObject.SetActive(true);
        print("现在是第3A页");
    }

    public void Page3B()
    {
        page3B_memory.gameObject.SetActive(true);
        button_down.gameObject.SetActive(true);
        button_down2.gameObject.SetActive(true);
        button_down3.gameObject.SetActive(true);
        print("现在是第3B页");
    }
    public void Page4()
    {
        page4_memory.gameObject.SetActive(true);
    }

    public void Page5()
    {
        page5_memory.gameObject.SetActive(true);
    }

    public void Page6()
    {
        page6_memory.gameObject.SetActive(true);
    }

    public void Page7()
    {
        page7_memory.gameObject.SetActive(true);
    }

    public void Page8()
    {
        page8_memory.gameObject.SetActive(true);
    }
}
