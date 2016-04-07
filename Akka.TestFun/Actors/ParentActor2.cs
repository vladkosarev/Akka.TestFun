using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Actor.Dsl;

namespace Akka.TestFun.Actors
{
    public class ParentActor : ReceiveActor
    {
        private readonly IActorRef _childActorRef;
        public ParentActor()
        {
            _childActorRef = Context.ActorOf(Props.Create(() => new ChildActor()));
            Receive<string>(message => 
            _childActorRef.Tell(message));
        }
    }
}
