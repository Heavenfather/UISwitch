/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-11
 * Description: 
 *				1.切换状态的数据，新增类型如果需要新的数据类型，可以在Data里面添加
 *				2.类型的枚举也放在这里吧，新增类型必须添加新的枚举
 *				3.新增类型也要到UISwitchInitialize处理
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toolkit
{
    /// <summary>
    /// 定义状态类型枚举
    /// </summary>
    public enum SwitchTypeEnum
    {
        Visible,
        Positon,
        Alpha,
        Text,
        Scale,
        Gray,
        Color,
        Rotation,

        Last,
    }

    /// <summary>
    /// 状态的初始化
    /// </summary>
    public class UISwitchInitialize
    {
#if UNITY_EDITOR
        public static string[] TypeNames;
#endif
        private static UISwitchTypeBase[] _stateBases = new UISwitchTypeBase[(int)SwitchTypeEnum.Last];

        static UISwitchInitialize()
        {
            _stateBases[(int)SwitchTypeEnum.Visible] = new UISwitchVisible();
            _stateBases[(int)SwitchTypeEnum.Positon] = new UISwitchPositon();
            _stateBases[(int)SwitchTypeEnum.Alpha] = new UISwitchAlpha();
            _stateBases[(int)SwitchTypeEnum.Text] = new UISwitchText();
            _stateBases[(int)SwitchTypeEnum.Scale] = new UISwitchScale();
            _stateBases[(int)SwitchTypeEnum.Gray] = new UISwitchGray();
            _stateBases[(int)SwitchTypeEnum.Color] = new UISwitchColor();
            _stateBases[(int)SwitchTypeEnum.Rotation] = new UISwitchRotation();

#if UNITY_EDITOR
            TypeNames = new string[_stateBases.Length];
            for (int i = 0; i < _stateBases.Length; i++)
            {
                TypeNames[i] = _stateBases[i].Name;
            }
#endif
        }

        public static UISwitchTypeBase GetStateBase(SwitchTypeEnum type)
        {
            return _stateBases[(int)type];
        }
    }

    [System.Serializable]
    public class StateConfig
    {
        public string StateName;

    }

    /// <summary>
    /// 状态用的各种数据
    /// </summary>
    [System.SerializableAttribute]
    public class UISwitchData
    {
        public bool isBool = true;

        public Vector3 v3Filed = Vector3.zero;

        public Vector2 v2Filed = Vector2.one;

        public float fValue = 0f;

        public string str;

        public Object obj;

        public Color color;
    }

}