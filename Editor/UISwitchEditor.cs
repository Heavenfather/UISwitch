/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-11
 * Description: 
 *				
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Toolkit
{
    [CustomEditor(typeof(UISwitch),true)]
    public class UISwitchEditor : UnityEditor.Editor
    {
        UISwitch _curSwitch;

        bool _showFoldout = true;

        private void OnEnable()
        {
            _curSwitch = this.target as UISwitch;
        }

        public override void OnInspectorGUI()
        {
            using (new AutoLabelWidth(100))
            {
                GUI.changed = false;
                using (new AutoBeginHorizontal())
                {
                    int stateIndex = EditorGUILayout.Popup("初始状态", _curSwitch.currentState, _curSwitch.StateNames);
                    if (GUI.changed)
                    {
                        RegisterUndo();
                        _curSwitch.currentState = stateIndex;
                    }

                    if (GUILayout.Button("+", GUILayout.Width(50)))
                    {
                        RegisterUndo();
                        _curSwitch.AddState();
                        //切换到新增的状态
                        _curSwitch.currentState = _curSwitch.stateConfigs.Length - 1;
                    }
                    if (GUILayout.Button("-", GUILayout.Width(50)))
                    {
                        if (_curSwitch.stateConfigs.Length <= 1)
                        {
                            Debug.LogWarning("至少保留一种状态");
                            return;
                        }
                        RegisterUndo();
                        _curSwitch.DeleteState(_curSwitch.currentState);
                        //删除状态就切换到倒数第一个那里
                        _curSwitch.currentState = _curSwitch.stateConfigs.Length - 1;
                    }
                }

                EditorGUILayout.Space();
                using (new AutoBeginHorizontal())
                {
                    int idx = EditorGUILayout.Popup("增加公有对象", -1, UISwitchInitialize.TypeNames);
                    if (idx != -1)
                    {
                        RegisterUndo();
                        _curSwitch.AddObject((SwitchTypeEnum)idx);
                    }
                }

                using (new AutoLabelWidth(60))
                {
                    OnDrawPublicObject();

                }
                GUILayout.Space(20);
                using (new AutoLabelWidth(35))
                {
                    using (new AutoBeginVertical("window"))
                    {
                        GUILayout.Space(-15);
                        using (new AutoBeginHorizontal())
                        {
                            GUILayout.Space(18);
                            OnDrawState();
                        }
                    }
                }                    
            }
        }

        public void OnDrawPublicObject()
        {
            if (_curSwitch.stateConfigs.Length <= 0) return;

            using (new AutoBeginVertical())
            {
                _showFoldout = EditorGUILayout.Foldout(_showFoldout, "控制对象列表", true);
                if (_showFoldout)
                {
                    EditorGUI.indentLevel++;
                    if (_curSwitch.switchObjects != null)
                    {
                        for (int i = 0; i < _curSwitch.switchObjects.Count;)
                        {
                            if (UISwitchDrawAgent.DrawSwitchObject(_curSwitch.switchObjects[i]))
                            {
                                RegisterUndo();
                                _curSwitch.DeleteObject(i);
                            }
                            else
                            {
                                ++i;
                            }
                        }
                    }
                    
                    EditorGUI.indentLevel--;
                }
                EditorGUI.indentLevel--;
            }
        }

        public void OnDrawState()
        {
            if (_curSwitch.stateConfigs.Length <= 0) return;
            using (new AutoBeginVertical())
            {
                _curSwitch.stateConfigs[_curSwitch.currentState].StateName = EditorGUILayout.TextField("状态名:", _curSwitch.stateConfigs[_curSwitch.currentState].StateName);
                
                GUILayout.Space(5);
                foreach (UISwitchObject item in _curSwitch.switchObjects)
                {
                    GUILayout.Space(5);
                    using (new AutoBeginHorizontal())
                    {
                        item.TypeBase.OnDrawStateObject(item);
                        UISwitchData data = item.holdObjDatas[_curSwitch.currentState];
                        GUILayout.Space(8);
                        if (item.TypeBase.OnDrawObjectData(item, data, _curSwitch.currentState))
                        {
                            item.TypeBase.Set(item, _curSwitch.currentState);
                        }
                    }
                }

            }
        }

        public void RegisterUndo()
        {
            Undo.RecordObject(target, "UISwitchRecord");
            EditorUtility.SetDirty(target);
        }

    }
}
