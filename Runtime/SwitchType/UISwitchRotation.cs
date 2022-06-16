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

namespace Toolkit
{
    public class UISwitchRotation : UISwitchType<Transform>
    {

        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
                data.v3Filed = obj.GetHoldObject<Transform>().localEulerAngles;
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject != null)
                obj.GetHoldObject<Transform>().localEulerAngles = obj.holdObjDatas[index].v3Filed;
        }

#if UNITY_EDITOR
        public override string Name { get { return "Ðý×ª"; } }

        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawV3Rotation(ref data.v3Filed, this.Name, obj.GetHoldObject<Transform>());
        }

#endif

    }
}
