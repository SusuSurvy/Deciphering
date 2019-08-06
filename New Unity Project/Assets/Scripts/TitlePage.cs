using System.Collections;
using System.Collections.Generic;
using Framework.Common;
using UnityEngine;

namespace Deciphering
{
    public class TitlePage : MonoBehaviour
    {
        public Animation m_ani;

        public GameObject StartBtn;

        public GameObject BookMain;

        public GameObject RollEffect;

        // Use this for initialization
        void Start()
        {
   
            BookMain.SetActive(false);
            RollEffect.SetActive(false);
            m_ani = transform.GetComponent<Animation>();
        }

        // Update is called once per frame
        void Update()
        {
          
        }

        public void OpenBook()
        {
            StartBtn.SetActive(false);
          
            m_ani.Play("close_open");

            Timer.New(0.8f, () =>
            {
                RollEffect.SetActive(true);
                BookMain.SetActive(true);
            });
            Timer.New(1.4f, () =>
            {
              gameObject.SetActive(false);
                PageMgr.Instance.ShowPage();
            });
        }
    }

}

