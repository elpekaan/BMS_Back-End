// Pagination Yapısı hakkında daha fazlası için;
// https://code-maze.com/paging-aspnet-core-webapi/
// https://www.youtube.com/watch?v=WmTiCtCYDGw

namespace Core.Utilities.Pagination;

public class PaginationParams
{
    private int _pageNumber { get; set; }
    private int _recordPerPage { get; set; }

    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value <= 0 ? 1 : value;
    }

    public int RecordPerPage
    {
        get => _recordPerPage;
        set => _recordPerPage = value > 50 ? 50 : value;
    }
}