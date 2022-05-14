// <copyright file="PublicationPaginatedSpecification.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace UNAProject.Core.Entities.PublicationAggregate.Specifications
{
    public class PublicationPaginatedSpecification : Specification<Publication>
    {
        public PublicationPaginatedSpecification(int skip, int take)
        {
            if (take == 0)
            {
                take = int.MaxValue;
            }

            Query
                .Skip(skip)
                .Take(take);
        }
    }
}
