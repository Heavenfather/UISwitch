using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public static class CommonExtension
{
    public static FileInfo[] GetFiles(this DirectoryInfo dir, params string[] searchPatterns)
    {
        var fileInfos = new List<FileInfo>();
        foreach (var pattern in searchPatterns)
        {
            var files = dir.GetFiles(pattern);
            fileInfos.AddRange(files);
        }
        return fileInfos.ToArray();
    }
    /// <summary>
    /// 修改或添加文件后缀
    /// </summary>
    /// <param name="source"></param>
    /// <param name="ext"></param>
    /// <returns></returns>
    public static string Ext(this string source, string ext)
    {
        if (string.IsNullOrEmpty(Path.GetExtension(source)))
        {
            return source.TrimEnd('/') + "." + ext.Replace(".", "");
        }
        return Path.ChangeExtension(source, ext);
    }
    /// <summary>
    /// 去Bom的字节数组解析为字符串
    /// </summary>
    /// <param name="encoding"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetStringWithoutBom(this Encoding encoding, byte[] bytes)
    {
        if (bytes == null || bytes.Length == 0) return "";
        if (bytes.Length <= 3)
        {
            return encoding.GetString(bytes);
        }
        var bomBytes = new byte[] { 0xEF, 0xBB, 0xBF };
        if (bytes[0] == bomBytes[0] && bytes[1] == bomBytes[1] && bytes[2] == bomBytes[2])
        {
            return encoding.GetString(bytes, 3, bytes.Length - 3);
        }
        return encoding.GetString(bytes);
    }
    public static Vector2 ToVector2(this Vector3 vec)
    {
        return new Vector2(vec.x, vec.y);
    }
    public static byte ToByte(this string val)
    {
        return string.IsNullOrEmpty(val) ? (byte)0 : Convert.ToByte(val);
    }
    public static int ToInt32(this string val)
    {
        return string.IsNullOrEmpty(val) ? 0 : Convert.ToInt32(val);
    }
    public static long ToInt64(this string val)
    {
        return string.IsNullOrEmpty(val) ? 0 : Convert.ToInt64(val);
    }
    public static double ToDouble(this string val)
    {
        return string.IsNullOrEmpty(val) ? 0 : Convert.ToDouble(val);
    }
    public static float ToFloat(this string val)
    {
        return string.IsNullOrEmpty(val) ? 0f : Convert.ToSingle(val);
    }
    public static bool ToBoolean(this string val)
    {
        return !string.IsNullOrEmpty(val)
            && (val.Equals("1") || val.Equals("t") || Convert.ToBoolean(val));
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
    public static void SetPositionX(this Transform transform, float x)
    {
        var position = transform.position;
        position.x = x;
        transform.position = position;
    }
    public static void SetPositionY(this Transform transform, float y)
    {
        var position = transform.position;
        position.y = y;
        transform.position = position;
    }
    public static void SetLocalPositionX(this Transform transform, float localX)
    {
        var position = transform.localPosition;
        position.x = localX;
        transform.localPosition = position;
    }
    public static void SetLocalPositionY(this Transform transform, float localY)
    {
        var position = transform.localPosition;
        position.y = localY;
        transform.localPosition = position;
    }
    public static string Join<T>(this IEnumerable<T> source, string sp)
    {
        var result = new StringBuilder();
        var first = true;
        foreach (T item in source)
        {
            if (first)
            {
                first = false;
                result.Append(item);
            }
            else
            {
                result.Append(sp).Append(item);
            }
        }
        return result.ToString();
    }

    /// <summary>
    /// 返回序列中的第一个元素。
    /// </summary>
    public static T First<T>(this IEnumerable<T> source)
    {
        var list = source.First<T>(1);
        foreach (var data in list)
            return data;
        return default(T);
    }

    /// <summary>
    /// 返回序列中的前面N个元素。
    /// </summary>
    public static IEnumerable<T> First<T>(this IEnumerable<T> source, int count)
    {
        if (source == null) return null;
        // 数组
        if (source is T[])
        {
            var elements = source as T[];
            if (elements.Length <= count) return elements;
            var results = new T[count];
            for (int index = 0; index < count; index++)
            {
                results[index] = elements[index];
            }
            return results;
        }
        // 集合
        else
        {
            var results = new List<T>();
            foreach (var element in source)
            {
                results.Add(element);
                if (results.Count == count)
                    return results;
            }
            return results;
        }
    }

    public static T Find<T>(this IEnumerable<T> source, Func<T, bool> findFunc)
    {
        foreach (var element in source)
        {
            if (findFunc(element))
            {
                return element;
            }
        }
        return default(T);
    }

    public static void Each<T>(this IEnumerable<T> source, Action<T> eachFunc)
    {
        foreach (var element in source)
        {
            eachFunc(element);
        }
    }

    public static T[] Insert<T>(this T[] arr,T item)
    {
        int len = arr.Length;
        System.Array.Resize<T>(ref arr, len + 1);
        arr[len] = item;
        return arr;
    }

    public static T[] RemoveAt<T>(this T[] arr,int index)
    {
        if (index < 0 || index >= arr.Length)
        {
            return null;
        }
        T[] newArr = new T[arr.Length - 1];
        if (index == 0)
        {
            System.Array.Copy(arr, 1, newArr, 0, newArr.Length);
        }
        else if(index == newArr.Length)
        {
            System.Array.Copy(arr, newArr, newArr.Length);
        }
        else
        {
            System.Array.Copy(arr, newArr, index);
            System.Array.Copy(arr, index + 1, newArr, index, arr.Length - index - 1);
        }
        return newArr;
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Func<T, bool> filterFunc)
    {
        var elements = new List<T>();
        source.Each((element) =>
        {
            if (filterFunc(element))
            {
                elements.Add(element);
            }
        });
        return elements;
    }

    public static bool Every<T>(this IEnumerable<T> source, Func<T, bool> everyFunc)
    {
        return source.Find((element) => !everyFunc(element)) == null;
    }

    public static bool Some<T>(this IEnumerable<T> source, Func<T, bool> someFunc)
    {
        return source.Find(someFunc) != null;
    }

    public static string ToFirstUpper(this string source)
    {
        if (string.IsNullOrEmpty(source) || source.Length <= 1) return source;
        var first = source.Substring(0, 1).ToUpper();
        var tail = source.Substring(1);
        return first + tail;
    }

    public static string ToFirstLower(this string source)
    {
        if (string.IsNullOrEmpty(source) || source.Length <= 1)
            return source;
        string first = source.Substring(0, 1).ToLower();
        string tail = source.Substring(1);
        return first + tail;
    }
    
    public static void SortKey<T, TV>(this Dictionary<T, TV> dic, Func<T, T, int> sortFunc)
    {
        if (dic.Count > 0)
        {
            List<KeyValuePair<T, TV>> lst = new List<KeyValuePair<T, TV>>(dic);
            lst.Sort((s1, s2) => sortFunc(s1.Key, s2.Key));
            dic.Clear();
            foreach (KeyValuePair<T, TV> kvp in lst)
            {
                dic[kvp.Key] = kvp.Value;
            }
        }
    }
}

