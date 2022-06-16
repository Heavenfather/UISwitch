/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-11
 * Description: 
 *				
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toolkit
{
    public class UISwitchVisible : UISwitchType<GameObject>
    {
        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject!=null)
            {
                data.isBool = obj.GetHoldObject<GameObject>().activeSelf;
            }
        }

        public override void Set(UISwitchObject obj,int index)
        {
            if (obj.holdObject != null)
            {
                obj.GetHoldObject<GameObject>().SetActive(obj.holdObjDatas[index].isBool);
            }
        }


#if UNITY_EDITOR
        public override string Name { get { return "¿É¼û"; } }
        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawToggle(ref data.isBool, "ÏÔÊ¾");
        }
#endif

    }
}
