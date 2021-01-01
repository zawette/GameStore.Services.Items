using System;

namespace Application.Exceptions
{
    [Serializable]
    public class ItemAlreadyExistsException : AppException
    {
        public override string Code { get; } = "item_already_exists";
        public Guid Id { get; }

        public ItemAlreadyExistsException(Guid id) : base($"item with id: {id} already exists.")
                => Id = id;
    }
}