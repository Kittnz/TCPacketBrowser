﻿using System;

namespace siof.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToStringSafe(this object obj)
        {
            return ToStringSafe(obj, null);
        }

        public static string ToStringSafe(this object obj, string defaultValue)
        {
            return obj.IfNotNull(o => o.ToString(), defaultValue);
        }

        public static TInput IfNotNull<TInput>(this TInput obj, Action<TInput> evaluator)
        {
            if (obj != null)
                evaluator(obj);

            return obj;
        }

        public static TResult IfNotNull<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator)
        {
            return IfNotNull(obj, evaluator, default(TResult));
        }

        public static TResult IfNotNull<TInput, TResult>(this TInput obj, Func<TInput, TResult> evaluator, TResult def)
        {
            if (obj != null)
                return evaluator(obj);

            return def;
        }
    }
}
