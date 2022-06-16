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

namespace Toolkit
{
    public class UISwitchPositon : UISwitchType<RectTransform>
    {
        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
                data.v3Filed = obj.GetHoldObject<RectTransform>().anchoredPosition;
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject!=null)
            {
                obj.GetHoldObject<RectTransform>().anchoredPosition = obj.holdObjDatas[index].v3Filed;
            }
        }

#if UNITY_EDITOR
        public override string Name { get { return "Œª÷√"; } }
        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawV3Pos(ref data.v3Filed, this.Name, obj.GetHoldObject<RectTransform>());
        }
#endif
    }
}
