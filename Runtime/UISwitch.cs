/****************************************************************
 * Author:tanhaiwen
 * CreateTime: 2022-6-11
 * Description: 
 *              UI�ڵ��л���������һ���������ڵ��ڲ�ͬ״̬�²�ͬ����ʾ
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toolkit
{
    [DisallowMultipleComponent]
    public sealed class UISwitch : MonoBehaviour
    {
        public List<UISwitchObject> switchObjects = new List<UISwitchObject>();
        public StateConfig[] stateConfigs = new StateConfig[1] { new StateConfig() { StateName = "0" } };

        [SerializeField]
        int _stateIndex;

        public int currentState
        {
            get
            {
                return _stateIndex;
            }
            set
            {
                if (_stateIndex == value) return;
                SwitchByIndex(value);
            }
        }

        private void Start()
        {
            SetState(currentState);
        }

        public void SwitchByIndex(int index)
        {
            SetState(index);
        }

        public void SwitchByName(string name)
        {
            for (int i = 0; i < stateConfigs.Length; i++)
            {
                if (stateConfigs[i].StateName == name)
                {
                    SetState(i);
                    break;
                }
            }
        }

        /// <summary>
        /// ���ڲ�ʹ�ã���粻�ٵ������
        /// </summary>
        /// <param name="state"></param>
        private void SetState(int state)
        {
            if (state < 0 || state >= stateConfigs.Length)
            {
                return;
            }
            _stateIndex = state;
            if (switchObjects != null)
            {
                for (int i = 0; i < switchObjects.Count; i++)
                {
                    switchObjects[i].TypeBase.Set(switchObjects[i], state);
                }
            }
        }

#if UNITY_EDITOR
        public void AddObject(SwitchTypeEnum type)
        {
            int count = stateConfigs.Length;
            UISwitchObject obj = new UISwitchObject();
            obj.type = type;
            obj.holdObjDatas = new UISwitchData[count];
            for (int i = 0; i < count; ++i)
            {
                obj.holdObjDatas[i] = new UISwitchData();
                obj.TypeBase.Init(obj, obj.holdObjDatas[i]);
            }

            if (switchObjects == null)
                switchObjects = new List<UISwitchObject>();
            switchObjects.Add(obj);
        }

        public void DeleteObject(int index)
        {
            if (switchObjects == null)
                return;
            switchObjects.RemoveAt(index);
        }

        public void AddState()
        {
            int len = stateConfigs.Length;
            StateConfig state = new StateConfig();
            state.StateName = len.ToString();
            stateConfigs = stateConfigs.Insert(state);

            if (switchObjects != null)
            {
                for (int i = 0; i < switchObjects.Count; i++)
                {
                    //����״̬���л�����Ҳ��Ҫ��������
                    switchObjects[i].holdObjDatas = switchObjects[i].holdObjDatas.Insert(new UISwitchData());
                    switchObjects[i].TypeBase.Init(switchObjects[i], switchObjects[i].holdObjDatas[switchObjects[i].holdObjDatas.Length - 1]);
                }
            }
        }

        public void DeleteState(int index)
        {
            stateConfigs = stateConfigs.RemoveAt(index);

            if (switchObjects != null)
            {
                for (int i = switchObjects.Count - 1; i >= 0; i--)
                {
                    switchObjects[i].holdObjDatas = switchObjects[i].holdObjDatas.RemoveAt(index);
                }
            }
        }

        public string[] StateNames
        {
            get
            {
                int count = stateConfigs.Length;
                string[] names = new string[count];
                for (int i = 0; i < count; i++)
                {
                    names[i] = stateConfigs[i].StateName;
                }
                return names;
            }
        }
#endif

    }
}
