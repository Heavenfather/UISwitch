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
	public abstract class UISwitchType<T> :UISwitchTypeBase where T : Object
	{
#if UNITY_EDITOR
        public override System.Type GetTypeValue()
        {
            return typeof(T);
        }

        public override void OnDraw(UISwitchObject obj)
        {
            Object target = UnityEditor.EditorGUILayout.ObjectField(obj.TypeBase.Name, obj.holdObject, this.GetTypeValue(), true);
            if (target != null && obj.holdObject == null)
            {
                RecordObjects("UISwitchRecord", target);
                obj.holdObject = target;
                if (obj.holdObjDatas!=null)
                {
                    for (int i = 0; i < obj.holdObjDatas.Length; i++)
                    {
                        obj.TypeBase.Init(obj, obj.holdObjDatas[i]);
                    }
                }

            }else if(target!=null && target.GetHashCode() != obj.holdObject.GetHashCode())
            {
                RecordObjects("UISwitchRecord", target);
                obj.holdObject = target;
            }
        }

        public override void OnDrawStateObject(UISwitchObject obj)
        {
            UnityEditor.EditorGUILayout.ObjectField(obj.TypeBase.Name, obj.holdObject, this.GetTypeValue(), true);
            GUILayout.Space(15);
        }

        public void RecordObjects(string name, params Object[] objs)
        {
            if (objs != null && objs.Length > 0 && objs[0] != null)
            {
                UnityEditor.Undo.RecordObjects(objs, name);
                foreach (Object obj in objs)
                {
                    if (obj == null) continue;
                    UnityEditor.EditorUtility.SetDirty(obj);
                }
            }
        }
#endif

    }
}
