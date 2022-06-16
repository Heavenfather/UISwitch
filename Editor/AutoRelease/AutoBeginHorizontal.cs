/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-14
 * Description: 
 *				
 ***************************************************************
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Toolkit
{
    public class AutoBeginHorizontal : IDisposable
    {

        public AutoBeginHorizontal()
        {
            EditorGUILayout.BeginHorizontal();
        }

        public AutoBeginHorizontal(params GUILayoutOption[] layoutOptions)
        {
            EditorGUILayout.BeginHorizontal(layoutOptions);
        }

        public AutoBeginHorizontal(GUIStyle style,params GUILayoutOption[] layoutOptions)
        {
            EditorGUILayout.BeginHorizontal(style, layoutOptions);
        }

        public void Dispose()
        {
            EditorGUILayout.EndHorizontal();
        }

    }
}
