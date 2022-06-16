/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-14
 * Description: 
 *				不同的切换状态绘制代理，新增类型需要新的数据来这里添加绘制
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Toolkit
{
	public class UISwitchDrawAgent
	{
#if UNITY_EDITOR

        public delegate void ActionRegister<T>(ref T obj);

		public static void RegisterUndo<T>(ActionRegister<T> action, ref T t, params Object[] objs)
        {
            var rs = new List<Object>();

            if (objs != null)
            {
                rs.AddRange(objs);
            }

            Undo.RecordObjects(rs.ToArray(), "UISwitchRecord");
            for (int i = 0; i < rs.Count; ++i)
                EditorUtility.SetDirty(rs[i]);

            action(ref t); 

            for (int i = 0; i < rs.Count; ++i)
                EditorUtility.SetDirty(rs[i]);
        }

        public static bool DrawSwitchObject(UISwitchObject obj)
        {
            bool del = false;
            EditorGUILayout.BeginHorizontal();
            obj.TypeBase.OnDraw(obj);
            if (GUILayout.Button("删除",GUILayout.Width(50)))
            {
                del = true;
            }
            EditorGUILayout.EndHorizontal();
            return del;
        }

        public static bool DrawToggle(ref bool value,string name)
        {
            var t = EditorGUILayout.Toggle(name, value);
            if (value == t)
            {
                return false;
            }
            RegisterUndo<bool>((ref bool v) =>
            {
                v = t;
            }, ref value);
            return true;
        }

        public static bool DrawV3Pos(ref Vector3 v3,string name,RectTransform target)
        {
            Vector3 inPos = EditorGUILayout.Vector3Field(name, v3);
            if (GUILayout.Button("Paste",GUILayout.Width(50)))
            {
                inPos = target.anchoredPosition;
            }
            if (v3 == inPos) return false;
            RegisterUndo<Vector3>((ref Vector3 v) =>
            {
                v = inPos;
            }, ref v3);
            return true;
        }

        public static bool DrawV3Rotation(ref Vector3 v3,string name,Transform target)
        {
            Vector3 inRo = EditorGUILayout.Vector3Field(name, v3);
            if (GUILayout.Button("Paster", GUILayout.Width(50)))
                inRo = target.localEulerAngles;
            if (inRo == v3) return false;
            RegisterUndo<Vector3>((ref Vector3 v) =>
            {
                v = inRo;
            }, ref v3);
            return true;
        }

        public static bool DrawV2Scale(ref Vector2 v2,string name, Transform target)
        {
            Vector2 inScale = EditorGUILayout.Vector2Field(name, v2);
            if (GUILayout.Button("Paste",GUILayout.Width(50)))
            {
                inScale = target.transform.localScale;
            }
            if (v2 == inScale) return false;
            RegisterUndo<Vector2>((ref Vector2 v) =>
            {
                v = inScale;
            }, ref v2);
            return true;
        }

        public static bool DrawFloatSlider(ref float f,string name)
        {
            float value = EditorGUILayout.Slider(name, f, 0, 1);
            if (f == value) return false;
            RegisterUndo<float>((ref float v) => 
            {
                v = value;
            },ref f);
            return true;
        }

        public static bool DrawTextField(ref string show,string name)
        {
            string input = EditorGUILayout.TextField(name, show);
            if (input == show) return false;
            RegisterUndo<string>((ref string v) =>
            {
                v = input;
            }, ref show);
            return true;
        }

        public static bool DrawColor(ref Color color,string name)
        {
            Color co = EditorGUILayout.ColorField(name, color);
            if (co == color) return false;
            RegisterUndo<Color>((ref Color v) =>
            {
                v = co;
            }, ref color);
            return true;
        }

#endif
    }
}
