using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.TestKit;

namespace Akka.TestFun
{
    public interface ISideEffect
    {
        void DoBadThings();
    }

    public class SideEffects : ISideEffect
    {
        public void DoBadThings()
        {
            throw new Exception("Doing Bad Things");
        }
    }

    public class FakeSideEffects : ISideEffect
    {
        private readonly IActorRef _testActorRef; 

        public FakeSideEffects(IActorRef testActorRef)
        {
            _testActorRef = testActorRef;
        }
        public void DoBadThings()
        {
            _testActorRef.Tell("Did Bad Things");
            //actorRef.Tell("got it");
        }
    }

}
