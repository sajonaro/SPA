namespace DataStore.Infrastructure
{
    using System;

    internal static class SyntaxSugar
    {
        /// <summary>
        /// sugar coated as operator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T As<T>(this object obj) where  T: class 
        {
            return obj as T;
        }

        public static bool IsOfType<T>(this Type obj) where T : class
        {
            return obj == typeof(T);
        }
    }
}
