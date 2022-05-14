using UNAProject.Web.ViewModels;

namespace UNAProject.Web.Interfaces
{
    public interface IPaginationService
    {
        PaginationInfosViewModel CreatePaginationInfos(int pageIndex, int itemsPerPage, int totalItemsCount);
    }
}
