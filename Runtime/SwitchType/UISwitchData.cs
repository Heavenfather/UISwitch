/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-11
 * Description: 
 *				1.�л�״̬�����ݣ��������������Ҫ�µ��������ͣ�������Data�������
 *				2.���͵�ö��Ҳ��������ɣ��������ͱ�������µ�ö��
 *				3.��������ҲҪ��UISwitchInitialize����
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toolkit
{
    /// <summary>
    /// ����״̬����ö��
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
    /// ״̬�ĳ�ʼ��
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
    /// ״̬�õĸ�������
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