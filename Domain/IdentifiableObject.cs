using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class IdentifiableObject
    {
        private readonly List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = idents.ToList();
        }

        public bool AreYou(string id) => _identifiers.Contains(id, StringComparer.InvariantCultureIgnoreCase);

        public string FirstId => _identifiers.FirstOrDefault();

        public void AddIdentifier(string id) => _identifiers.Add(id);
    }
}
