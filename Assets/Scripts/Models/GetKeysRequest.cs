using System;
using JetBrains.Annotations;

namespace Models
{
    [Serializable]
    public class GetKeysRequest
    {
        [CanBeNull] public string Token { get; set; }
    }
}