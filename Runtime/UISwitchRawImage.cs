/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-7-19
 * Description: 
 *				
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toolkit
{
    public class UISwitchRawImage : UISwitchType<RawImage>
    {

        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
            {
                data.obj = obj.GetHoldObject<RawImage>().texture;
                data.isBool = false;
            }
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject!=null)
            {
                obj.GetHoldObject<RawImage>().texture = obj.holdObjDatas[index].obj as Texture2D;
                if (obj.holdObjDatas[index].isBool)
                {
                    obj.GetHoldObject<RawImage>().SetNativeSize();
                }
            }
        }

#if UNITY_EDITOR
        public override string Name { get { return "RawImage"; } }
        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            bool b1 = UISwitchDrawAgent.DrawObject(ref data.obj, typeof(Texture2D));
            bool b2 = UISwitchDrawAgent.DrawToggle(ref data.isBool, "Is native");
            return b1 || b2;
        }

#endif

    }
}
