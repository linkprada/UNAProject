// <copyright file="PublicationWithAttachmentsSpecification.cs" company="linkprada">
// Copyright (c) linkprada. All rights reserved.
// </copyright>

using Ardalis.Specification;

namespace UNAProject.Core.Entities.PublicationAggregate.Specifications
{
    public class PublicationWithAttachmentsSpecification : Specification<Publication>, ISingleResultSpecification
    {
        public PublicationWithAttachmentsSpecification(int publicationId)
        {
            Query
                .Where(publication => publication.Id == publicationId)
                .Include(publication => publication.Attachments);
        }
    }
}
