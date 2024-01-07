using Castle.DynamicProxy;

namespace Core.Interceptors;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class MethodInterceptionBaseAttribute : Attribute,IInterceptor
{
    public int Priority { get; set; }

    public virtual void Intercept(IInvocation invocation)
    {
    }
}
