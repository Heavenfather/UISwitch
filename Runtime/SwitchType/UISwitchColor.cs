/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-16
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
    public class UISwitchColor : UISwitchType<MaskableGraphic>
    {
        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
                data.color = obj.GetHoldObject<MaskableGraphic>().color;
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject!=null)
            {
                obj.GetHoldObject<MaskableGraphic>().color = obj.holdObjDatas[index].color;
            }
        }

#if UNITY_EDITOR
        public override string Name { get { return "ÑÕÉ«"; } }
        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawColor(ref data.color, this.Name);
        }
#endif

    }
}
