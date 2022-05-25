using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Models
{
    [Serializable]
    public class GetKeysResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
        [CanBeNull] public List<Key> Keys { get; set; }
    }
}