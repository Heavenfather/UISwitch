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
    public class AutoToggleGroup : IDisposable
    {
        public bool toggle { get; set; }

        public AutoToggleGroup(bool active,string name = "")
        {
            toggle = EditorGUILayout.BeginToggleGroup(name, active);
        }

        public void Dispose()
        {
            EditorGUILayout.EndToggleGroup();
        }

    }
}
