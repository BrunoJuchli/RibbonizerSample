﻿namespace Ribbonizer.Reflection
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using System.Reflection;

    using Appccelerate;

    public static class Reflector<TTarget>
    {
        private const string EnumerationValueNotConstant = "Specified enumeration value is not a constant expression.";
        private const string MemberIsNotAccess = "Specified member is not a member access expression.";
        private const string MemberIsNotField = "Specified member is not a field.";
        private const string MemberIsNotProperty = "Specified member is not a property.";
        private const string MethodIsNotCall = "Specified method is not a method call expression.";

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static MethodInfo GetMethod(Expression<Action<TTarget>> methodSelector)
        {
            return GetMethodInfo(methodSelector);
        }

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static MethodInfo GetMethod<T1>(Expression<Action<TTarget, T1>> methodSelector)
        {
            return GetMethodInfo(methodSelector);
        }

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static MethodInfo GetMethod<T1, T2>(Expression<Action<TTarget, T1, T2>> methodSelector)
        {
            return GetMethodInfo(methodSelector);
        }

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static MethodInfo GetMethod<T1, T2, T3>(Expression<Action<TTarget, T1, T2, T3>> methodSelector)
        {
            return GetMethodInfo(methodSelector);
        }

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static string GetPropertyName<TResult>(Expression<Func<TTarget, TResult>> propertySelector)
        {
            return GetProperty(propertySelector).Name;
        }

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static PropertyInfo GetProperty<TResult>(Expression<Func<TTarget, TResult>> propertySelector)
        {
            var info = GetMemberInfo(propertySelector) as PropertyInfo;
            Ensure.ArgumentMatches(info != null, MemberIsNotProperty);

            return info;
        }

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static FieldInfo GetField<TResult>(Expression<Func<TTarget, TResult>> fieldSelector)
        {
            var info = GetMemberInfo(fieldSelector) as FieldInfo;
            Ensure.ArgumentMatches(info != null, MemberIsNotField);

            return info;
        }

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes", Justification = "Required for simplified usage of methods.")]
        public static FieldInfo GetEnumerationValue<TResult>(Expression<Func<TResult>> enumerationValueSelector)
        {
            return GetEnumInfo(enumerationValueSelector);
        }

        private static MethodInfo GetMethodInfo(LambdaExpression methodSelector)
        {
            Ensure.ArgumentMatches(methodSelector.Body.NodeType == ExpressionType.Call, MethodIsNotCall);

            var callExpression = (MethodCallExpression)methodSelector.Body;
            return callExpression.Method;
        }

        private static MemberInfo GetMemberInfo(LambdaExpression memberSelector)
        {
            Ensure.ArgumentMatches(memberSelector.Body.NodeType == ExpressionType.MemberAccess, MemberIsNotAccess);

            var memberExpression = (MemberExpression)memberSelector.Body;
            return memberExpression.Member;
        }

        private static FieldInfo GetEnumInfo(LambdaExpression enumerationValueSelector)
        {
            Ensure.ArgumentMatches(enumerationValueSelector.Body.NodeType == ExpressionType.Constant, EnumerationValueNotConstant);

            var constantExpression = (ConstantExpression)enumerationValueSelector.Body;

            string enumName = constantExpression.Type.GetEnumName(constantExpression.Value);
            return constantExpression.Type.GetField(enumName);
        }
    }
}