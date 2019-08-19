using CM.Voice.VoiceApi.Sdk.Models.Events.Apps;
using System.Collections.Generic;

namespace Tests
{
    public sealed class CallQueuedEventEqualityComparer : IEqualityComparer<CallQueuedEvent>
    {
        public bool Equals(CallQueuedEvent x, CallQueuedEvent y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.CallId.Equals(y.CallId) && string.Equals(x.InstructionId, y.InstructionId) && string.Equals(x.Caller, y.Caller) && string.Equals(x.Callee, y.Callee) && x.Success == y.Success && string.Equals(x.Error, y.Error);
        }

        public int GetHashCode(CallQueuedEvent obj)
        {
            unchecked
            {
                var hashCode = obj.Caller != null ? obj.Caller.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ obj.CallId.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.InstructionId != null ? obj.InstructionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (obj.Callee != null ? obj.Callee.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ obj.Success.GetHashCode();
                hashCode = (hashCode * 397) ^ (obj.Error != null ? obj.Error.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}