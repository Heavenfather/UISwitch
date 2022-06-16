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
    public abstract class UISwitchTypeBase
    {
        public abstract void Init(UISwitchObject obj, UISwitchData data);

        public abstract void Set(UISwitchObject obj,int index);

#if UNITY_EDITOR
        public abstract System.Type GetTypeValue();
        /// <summary>
        /// 绘制公有对象
        /// </summary>
        /// <param name="obj"></param>
        public abstract void OnDraw(UISwitchObject obj);
        /// <summary>
        /// 绘制状态下的对象
        /// </summary>
        /// <param name="obj"></param>
        public abstract void OnDrawStateObject(UISwitchObject obj);
        /// <summary>
        /// 绘制每个对象的操作数据
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="data"></param>
        /// <param name="index"></param>
        public abstract bool OnDrawObjectData(UISwitchObject obj, UISwitchData data, int index);

        public abstract string Name { get; }
#endif


    }
}
