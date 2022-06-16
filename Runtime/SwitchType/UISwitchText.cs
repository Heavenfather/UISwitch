/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-15
 * Description: 
 *				1.不同的文本状态，输入的是多语言的key值，key值再进行查找转换
 *				2.多余处是调用的lua层，所以仅运行时生效
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toolkit
{
    public class UISwitchText : UISwitchType<Text>
    {
        public override void Init(UISwitchObject obj, UISwitchData data)
        {
            if (obj.holdObject != null)
            {
                string key = obj.GetHoldObject<Text>().text;
                string value = LanguageUtil.GetText(key);
                data.str = value;
            }
        }

        public override void Set(UISwitchObject obj, int index)
        {
            if (obj.holdObject != null)
            {
                string value = LanguageUtil.GetText(obj.holdObjDatas[index].str);
                obj.GetHoldObject<Text>().text = value;
            }
        }

#if UNITY_EDITOR
        public override string Name { get { return "文本"; } }

        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawTextField(ref data.str, "多语言");
        }

#endif

    }
}
