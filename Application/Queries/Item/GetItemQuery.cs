﻿using Application.DTO;
using MediatR;
using System;

namespace Application.Queries
{
    public class GetItemQuery : IRequest<ItemDTO>
    {
        public Guid Id { get; set; }
    }
}