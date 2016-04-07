using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using Akka.Actor;
using Akka.DI.Core;

namespace Akka.TestFun.Actors
{
    public class ChildActor : ReceiveActor
    {
        private readonly IActorRef _subChildActorRef;
        public ChildActor()
        {
            _subChildActorRef = Context.ActorOf(Context.DI().Props<SubChildActor>());
            Receive<string>(message => 
            _subChildActorRef.Tell(message));
        }
    }
}
