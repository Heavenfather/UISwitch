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

namespace Toolkit
{
	public class AutoLabelWidth : IDisposable
    {
        float old;

        public AutoLabelWidth(float width)
        {
            old = UnityEditor.EditorGUIUtility.labelWidth;
            UnityEditor.EditorGUIUtility.labelWidth = width;
        }

        public void Dispose()
        {
            UnityEditor.EditorGUIUtility.labelWidth = old;
        }
	}
}
