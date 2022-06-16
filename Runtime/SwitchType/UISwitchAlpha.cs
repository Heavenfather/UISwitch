/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-15
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
    public class UISwitchAlpha : UISwitchType<MaskableGraphic>
    {
        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
                data.fValue = obj.GetHoldObject<MaskableGraphic>().color.a;
        }


        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject!=null)
            {
                Color newColor = obj.GetHoldObject<MaskableGraphic>().color;
                newColor.a = obj.holdObjDatas[index].fValue;
                obj.GetHoldObject<MaskableGraphic>().color = newColor;
            }
        }

#if UNITY_EDITOR
        public override string Name { get { return "Í¸Ã÷¶È"; } }
        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawFloatSlider(ref data.fValue, this.Name);
        }
#endif

    }
}
