using IsracardMvcAngularJS.Core.interfaces;
using System;
using System.Collections.Generic;
using IsracardMvcAngularJS.Core.models;
using System.Linq;

namespace IsracardMvcAngularJS.Core
{
    public class RepositoryService : IRepositoryService
    {
        private readonly IDataStorageService<List<Repository>> _dataStorageService;
        private const string SESSIONKEY = "bookmarkedRepos";

        public RepositoryService(IDataStorageService<List<Repository>> dataStorageService)
        {
            _dataStorageService = dataStorageService;
        }
        public void BookmarkRepository(Repository repoToBookmark)
        {
            var bookmarkedRepos = GetBookmarkedRepositories();

            if (bookmarkedRepos.Any(x => x.id == repoToBookmark.id))
                bookmarkedRepos.Remove(bookmarkedRepos.First(x => x.id == repoToBookmark.id));
            else
                bookmarkedRepos.Add(repoToBookmark);

            _dataStorageService.Save(SESSIONKEY, bookmarkedRepos);
        }

        public List<Repository> GetBookmarkedRepositories()
        {
            var repos = _dataStorageService.Get(SESSIONKEY);
            return (repos == null) ? new List<Repository>() : repos;
        }
    }
}