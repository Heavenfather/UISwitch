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
    public class UISwitchScale : UISwitchType<Transform>
    {

        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
                data.v2Filed = obj.GetHoldObject<Transform>().localScale;
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject != null)
                obj.GetHoldObject<Transform>().localScale = obj.holdObjDatas[index].v2Filed;
        }

#if UNITY_EDITOR
        public override string Name { get { return "Ëõ·Å"; } }

        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawV2Scale(ref data.v2Filed, this.Name, obj.GetHoldObject<Transform>());
        }

#endif

    }
}
