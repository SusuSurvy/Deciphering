using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Framework.Common;
using UnityEngine;

namespace Deciphering
{
 
    public class NormalPage:MonoBehaviour
    {
        private GameObject m_PhObj;
        private List<SpriteRenderer> rendersPic;
        private List<SpriteRenderer> rendersOther;

        public bool IsShowNextBtn = true;
        private void Start()
        {
            m_PhObj = this.gameObject;
            rendersPic=new List<SpriteRenderer>();

            rendersOther=new List<SpriteRenderer>();
            foreach (Transform trans in m_PhObj.transform)
            {
                if (trans.name.Contains("pic"))
                {
                    SpriteRenderer render = trans.GetComponent<SpriteRenderer>();
                    if(render!=null)
                    rendersPic.Add(render);
                }
                else
                {
                    SpriteRenderer render = trans.GetComponent<SpriteRenderer>();
                    if (render != null)
                        rendersOther.Add(render);
                }
            }
      
        }

        public void HidePage()
        {
            float myValue = 1;
            for (int i = 0; i < rendersPic.Count; i++)
            {
                SpriteRenderer render = rendersPic[i];
              
                Tweener tweener = DOTween.To(() => myValue, x => myValue = x, 0, 1f);

                tweener.onUpdate = () =>
                {

                    render.color = new Color(1, 1, 1, myValue);
                };
                //tweener.onComplete = DoBuildingDead;
            }

            float myValue11 = 1;
            for (int i = 0; i < rendersOther.Count; i++)
            {
                SpriteRenderer render = rendersOther[i];
       
                Tweener tweener = DOTween.To(() => myValue11, x => myValue11 = x, 0, 1f);

                tweener.onUpdate = () =>
                {

                    render.color = new Color(1, 1, 1, myValue11);

                };

                tweener.onComplete = () =>
                {
                    m_PhObj.SetActive(false);
                };
            }

        }

        public void ShowPage()
        {
            m_PhObj.SetActive(true);
            float myValue = 0;
            for (int i = 0; i <rendersPic.Count; i++)
            {
                SpriteRenderer render = rendersPic[i];
                render.color=new Color(1,1,1,0);
                Tweener tweener = DOTween.To(() => myValue, x => myValue = x, 1, 1.5f);
             
                tweener.onUpdate = () =>
                {

                    render.color = new Color(1,1,1, myValue);
                   
                };
              
              
            }

            float myValue1 = 0;
            for (int i = 0; i < rendersOther.Count; i++)
                {
                    SpriteRenderer render = rendersOther[i];
                    render.color = new Color(1, 1, 1, 0);
                    Timer.New(1f, () =>
                    {
                        Tweener tweener = DOTween.To(() => myValue1, x => myValue1 = x, 1, 1.5f);

                        tweener.onUpdate = () =>
                        {

                            render.color = new Color(1, 1, 1, myValue1);

                        };
                        tweener.onComplete = () =>
                        {
                            if (IsShowNextBtn)
                            {
                                PageMgr.Instance.ShowNextBtn(true);
                             
                            }
                            PageMgr.Instance.ShowReturnBtn(true);


                        };

                    });
                }
        }

        public int Index;
        public TransitPage TransitPage;
        [HideInInspector]
        public NormalPage LastPage;
        [HideInInspector]
        public NormalPage NextPage;
        // Use this for initialization
       
        // Update is called once per frame
        void Update()
        {

        }
    }

}

