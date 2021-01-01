using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ItemNotFoundException : AppException
    {
        public override string Code { get; } = "item_not_found";
        public Guid Id { get; }

        public ItemNotFoundException(Guid id) : base($"item with id: {id} doesn't exists.")
                => Id = id;
    }
}
