/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-15
 * Description: 
 *				1.置灰控件
 *				2.依赖动态资源加载，仅运行时生效
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toolkit
{
    public class UISwitchGray : UISwitchType<Graphic>
    {
        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
            {
                Graphic g = obj.GetHoldObject<Graphic>();
                if (g.material == null)
                {
                    ResManager.Instance.LoadAssetAsync("Material/UIDefault.mat", obj.holdObject, typeof(Material), (mat) =>
                       {
                           data.obj = mat;
                       });
                }
                else
                {
                    data.obj = g.material;
                }
                data.isBool = false;
            }
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject != null)
            {
                if (!Application.isPlaying)
                    return;

                if (obj.holdObjDatas[index].isBool)
                {
                    ResManager.Instance.LoadAssetAsync("Material/UIDefaultGrey.mat", obj.holdObject, typeof(Material), (mat) =>
                    {
                        obj.GetHoldObject<Graphic>().material = mat as Material;
                    });
                }
                else
                {
                    ResManager.Instance.LoadAssetAsync("Material/UIDefault.mat", obj.holdObject, typeof(Material), (mat) =>
                    {
                        obj.GetHoldObject<Graphic>().material = mat as Material;
                    });
                }
            }
        }

#if UNITY_EDITOR
        public override string Name { get { return "置灰"; } }

        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawToggle(ref data.isBool, "是否灰");
        }

#endif

    }
}
