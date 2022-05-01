using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNAProject.Core.Entities.PublicationAggregate;
using UNAProject.Core.Entities.PublicationAggregate.Specifications;
using Xunit;

namespace UNAProject.UnitTests.Core.Specifications
{
    public class PublicationWithAttachmentsSpec
    {
        [Fact]
        public void PublicationWithAttachmentsSpec_GetPublicationWithItsAttchments()
        {
            var publicationId = 42;
            var specification = new PublicationWithAttachmentsSpecification(publicationId);

            // TODO: INVESTIGATE the list is returned with child lists even if you remove "include" clause in the specification
            var publicationWithAttachments = specification.Evaluate(GetPublicationsListTest()).SingleOrDefault();

            Assert.NotNull(publicationWithAttachments);
            Assert.Equal(publicationId, publicationWithAttachments.Id);
            Assert.Equal(2, publicationWithAttachments.Attachments.Count());
        }

        private List<Publication> GetPublicationsListTest()
        {
            var publication1 = new Publication("PublicationTest1", PublicationType.Event);
            publication1.Id = 3;
            publication1.AddAttachments(new Attachment("Attachment1Test", AttachmentType.Image));
            publication1.AddAttachments(new Attachment("Attachment2Test", AttachmentType.File));

            var publication2 = new Publication("PublicationTest2", PublicationType.Event);
            publication2.Id = 42;
            publication2.AddAttachments(new Attachment("Attachment3Test", AttachmentType.Image));
            publication2.AddAttachments(new Attachment("Attachment4Test", AttachmentType.File));

            var publication3 = new Publication("PublicationTest3", PublicationType.Event);
            publication3.Id = 137;
            publication3.AddAttachments(new Attachment("Attachment5Test", AttachmentType.Image));
            publication3.AddAttachments(new Attachment("Attachment6Test", AttachmentType.File));

            return new List<Publication>() { publication1, publication2, publication3 };
        }
    }
}
