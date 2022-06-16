/****************************************************************
 * Author: tanhaiwen
 * CreateTime: 2022-6-14
 * Description: 
 *				
 ***************************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

namespace Toolkit
{
    public class AutoBeginVertical : IDisposable
    {
        public AutoBeginVertical()
        {
            EditorGUILayout.BeginVertical();
        }

        public AutoBeginVertical(params GUILayoutOption[] layoutOptions)
        {
            EditorGUILayout.BeginVertical(layoutOptions);
        }

        public AutoBeginVertical(GUIStyle style, params GUILayoutOption[] layoutOptions)
        {
            EditorGUILayout.BeginVertical(style, layoutOptions);
        }

        public void Dispose()
        {
            EditorGUILayout.EndVertical();
        }

    }
}
