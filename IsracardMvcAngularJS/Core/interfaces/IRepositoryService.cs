using IsracardMvcAngularJS.Core.models;
using System.Collections.Generic;

namespace IsracardMvcAngularJS.Core.interfaces
{
    public interface IRepositoryService
    {
        List<Repository> GetBookmarkedRepositories();
        void BookmarkRepository(Repository repoToBookmark);
    }
}