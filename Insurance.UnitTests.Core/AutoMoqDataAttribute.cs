using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Insurance.UnitTests.Core
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public sealed class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() =>
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());
                return fixture;
            })
        {
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class AutoMoqInlineDataAttribute : InlineAutoDataAttribute
    {
        public AutoMoqInlineDataAttribute(params object[] objects)
            : base(new AutoMoqDataAttribute(), objects)
        {
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class MemberAutoMoqDataAttribute : MemberAutoDataAttribute
    {
        public MemberAutoMoqDataAttribute(string memberName, params object[] parameters)
            : base(new AutoMoqDataAttribute(), memberName, parameters)
        {
        }
    }
}
