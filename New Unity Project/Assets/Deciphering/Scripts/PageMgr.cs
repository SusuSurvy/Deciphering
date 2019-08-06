using System.Collections;
using System.Collections.Generic;
using Framework.Common;
using UnityEngine;

namespace Deciphering
{
    public class PageMgr : MonoBehaviour
    {
        public static PageMgr Instance
        {
            get { return m_instance; }
        }
    
        private List<NormalPage> _pagePools;
        public TitlePage TitlePage;
        public Animation RollAnimation;
        public GameObject NextBtn;

        public GameObject ReturnBtn;
        private static PageMgr m_instance;

        private NormalPage m_currentPage;
        private NormalPage m_lastPage;
        private int m_currentPageNum = 0;

        private void Awake()
        {
            m_instance = this;
            m_lastPage = null;
        }

        void Start()
        {
            NextBtn.SetActive(false);
            ReturnBtn.SetActive(false);
            _pagePools = new List<NormalPage>();
            foreach (Transform trans in transform)
            {
                trans.gameObject.SetActive(false);
                NormalPage page = trans.GetComponent<NormalPage>();
                _pagePools.Add(page);
            }
            Debug.Log(_pagePools.Count);
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

                if (hit.collider != null)
                {
               
                    //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                    if (hit.collider.gameObject.name == "start")
                    {
                        TitlePage.OpenBook();
                    }
                    if (hit.collider.gameObject.name == "next_page")
                    {
                        ShowNextBtn(false);
                        ShowReturnBtn(false);
                        if (m_lastPage != null)
                        {
                            m_lastPage.HidePage();
                            Timer.New(1f, () =>
                            {
                                RollPage();
                                m_currentPageNum++;
                            });
                        }
                        else
                        {
                            RollPage();
                            m_currentPageNum++;
                        }

                        
                        

                    }
                    if (hit.collider.gameObject.name == "return_page")
                    {
                        ShowNextBtn(false);
                        ShowReturnBtn(false);
                        if (m_lastPage != null)
                        {
                            m_lastPage.HidePage();
                            Timer.New(1f, () =>
                            {
                                RollPage(false);
                                m_currentPageNum--;
                            });
                        }
                        else
                        {
                            RollPage(false);
                            m_currentPageNum--;
                        }




                    }
                }
            }
        }

        public void ShowPage()
        {
            _pagePools[m_currentPageNum].ShowPage();
            m_lastPage = _pagePools[m_currentPageNum];
        }

        public void RollPage(bool isNext=true)
        {
       if(isNext)
            RollAnimation.Play("page");
       else
       {
           RollAnimation.Play("return");
            }
           
            Timer.New(1.5f, () =>
            {
                ShowPage();
            });
        }

        public void ShowNextBtn(bool val)
        {

            NextBtn.SetActive(val);
          
          
        }

        public void ShowReturnBtn(bool val)
        {
            if (m_currentPageNum > 0 && val)
            {
                ReturnBtn.SetActive(true);
                return;
            }
            ReturnBtn.SetActive(false);



        }
    }

}

