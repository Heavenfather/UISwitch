/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-11
 * Description: 
 *				1.UI²Ù×÷¶ÔÏó
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toolkit
{
	[System.Serializable]
	public class UISwitchObject
	{
		[SerializeField]
		string typeKey = "";

		public Object holdObject;
		public UISwitchData[] holdObjDatas;

        public SwitchTypeEnum type
        {
            get { return (SwitchTypeEnum)System.Enum.Parse(typeof(SwitchTypeEnum), typeKey); }
            set { typeKey = value.ToString(); }
        }

		public UISwitchTypeBase TypeBase { get { return UISwitchInitialize.GetStateBase(this.type); } }

		public T GetHoldObject<T>() where T : Object
        {
			return holdObject as T;
        }

    }
}
