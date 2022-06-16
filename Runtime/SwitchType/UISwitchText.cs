/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-15
 * Description: 
 *				1.��ͬ���ı�״̬��������Ƕ����Ե�keyֵ��keyֵ�ٽ��в���ת��
 *				2.���ദ�ǵ��õ�lua�㣬���Խ�����ʱ��Ч
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
        public override string Name { get { return "�ı�"; } }

        public override bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index)
        {
            return UISwitchDrawAgent.DrawTextField(ref data.str, "������");
        }

#endif

    }
}
