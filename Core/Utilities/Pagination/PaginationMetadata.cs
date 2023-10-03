// Information about Offset-Based Pagination;
// https://code-maze.com/paging-aspnet-core-webapi/
// https://www.youtube.com/watch?v=WmTiCtCYDGw

namespace Core.Utilities.Pagination;

public class PaginationMetadata
{
    public PaginationMetadata(int totalItemsInDatabase, int currentPage, int itemsPerPage)
    {
        TotalItemsInDatabase = totalItemsInDatabase;
        CurrentPage = currentPage;
        TotalPages = (int) Math.Ceiling(totalItemsInDatabase / (double) itemsPerPage);
    }

    public int CurrentPage { get; private set; }
    public int TotalItemsInDatabase { get; private set; }
    public int TotalPages { get; private set; }

    public bool HasPrevious => CurrentPage > 1;
    public bool HasNext => CurrentPage < TotalPages;
}