using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace Akka.TestFun.Actors
{
    public class SubChildActor2 : ReceiveActor
    {
        public SubChildActor2(ISideEffect sideEffect)
        {
            Receive<string>(message => 
            sideEffect.DoBadThings());
        }
    }
}
