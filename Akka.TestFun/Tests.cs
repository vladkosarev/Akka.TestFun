using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using Akka.TestFun.Actors;
using Autofac;
using Xunit;

namespace Akka.TestFun
{
    public class SupervisorHierarchySpec : TestKit.Xunit2.TestKit
    {         
        [Fact]
        public void Test()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => new FakeSideEffects(TestActor)).As<ISideEffect>();
            builder.RegisterType<ParentActor>();
            builder.RegisterType<ChildActor>();
            builder.RegisterType<SubChildActor>();
            var container = builder.Build();
            
            var propsResolver = new AutoFacDependencyResolver(container, Sys);
            
            var parentActorProps = Sys.DI().Props<ParentActor>();
            var parentActor = Sys.ActorOf(parentActorProps);
            parentActor.Tell("Test", TestActor);
            ExpectMsg("Did Bad Things");
            //ExpectNoMsg(TimeSpan.FromMinutes(1));
        }
    }
}
