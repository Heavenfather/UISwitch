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
    public class UISwitchImage : UISwitchType<Image>
    {

        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
            {
                Image img = obj.GetHoldObject<Image>();
                data.obj = img.sprite;
                data.isBool = false;
            }
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject != null)
            {
                obj.GetHoldObject<Image>().sprite = obj.holdObjDatas[index].obj as Sprite;
                if (obj.holdObjDatas[index].isBool)
                {
                    obj.GetHoldObject<Image>().SetNativeSize();
                }
            }
        }

#if UNITY_EDITOR
        public override string Name { get { return "Image"; } }
        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            bool b1 = UISwitchDrawAgent.DrawObject(ref data.obj, typeof(Sprite));
            UnityEditor.EditorGUILayout.Space(-65);
            bool b2 = UISwitchDrawAgent.DrawToggle(ref data.isBool, "Is native");
            return b1 || b2;
        }

#endif

    }
}
