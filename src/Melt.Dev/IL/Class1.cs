using Melt.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace Melt
{
    class MyClass
    {
        public static T Clone<T>(MethodInfo method) where T : Delegate
        {
            var dependency = new object();

            var body = method.GetMethodBody();
            var maxStackSize = body.MaxStackSize;
            var paraList = method.GetParameters().Aggregate(new List<Type> { dependency.GetType() }, (l, pt) =>
            {
                l.Add(pt.ParameterType);
                return l;
            });
            var localVariables = body.LocalVariables.Select(l => (l.LocalType, l.IsPinned));
            var il = body.GetILAsByteArray();
            var ret = method.ReturnType;

            var module = Assembly.GetExecutingAssembly().ManifestModule;// method.Module;



            var rtType = method.GetType();
            var methodCtx = (method as MethodBase) is ConstructorInfo ? null : method.GetGenericArguments();
            var typeCtx = (method.DeclaringType == null) ? null : method.DeclaringType.GetGenericArguments();

            var dm = new DynamicMethod("_" + Guid.NewGuid().ToString("X").Replace("-", null), ret, paraList.ToArray(), paraList[0], true);
            var ilInfo = dm.GetDynamicILInfo();
            var sig = SignatureHelper.GetLocalVarSigHelper();
            foreach (var lvi in localVariables)
                sig.AddArgument(lvi.LocalType, lvi.IsPinned);
            ilInfo.SetLocalSignature(sig.GetSignature());

            var visitor = new DynamicMethodHelper.ILInfoGetTokenVisitor(ilInfo, il);
            var reader = new ILReader(rtType, il, module, methodCtx, typeCtx);
            reader.Accept(visitor);
            ilInfo.SetCode(il, maxStackSize);

            var dele = dm.CreateDelegate(typeof(T), dependency) as T;

            return dele;
        }
    }

}
