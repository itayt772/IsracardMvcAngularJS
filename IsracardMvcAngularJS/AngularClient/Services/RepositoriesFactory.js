var RepositoriesFactory = function ($http) {
    'use strict';

    // should get this values from config env.
    var gitApiUrl = 'https://api.github.com/';
    var repoApiUrl = '';

    var bookmarkRepositories = [];

    // init bookmarkRepos - selfinvoke so we can get results on load
    var initBookmarkedReposFromServer = function () {
        $http.post(repoApiUrl + '/repositories/GetBookmarkedRepositories')
            .then(function (result) {
                bookmarkRepositories = result.data.bookmarkredRepos;
            });
    }();

    var getBookmarkedRepositories = function () {
        return bookmarkRepositories;
    }

    // return promise
    var getRepositories = function (searchWord) {
        return $http.get(gitApiUrl + 'search/repositories?q=' + searchWord);
    }

    // check if repositry is bookmarked by id
    var isRepositoryBookmarked = function (repoId) {
        for(var i = 0; i < bookmarkRepositories.length; i++) {
            if (bookmarkRepositories[i].id === repoId) return true;
        }
        return false;
    }

    // if repositry is bookmarked lets remove it from there,
    // else lets add new bookmark id
    var toggleRepositoryBookmark = function (repo) {
        // request to server first
        $http.post(repoApiUrl + '/repositories/SetBookmarkRepository', {
            repository: repo
        })
        .then(function (result) {
            bookmarkRepositories = result.data.bookmarkredRepos;
        });
    }

    return {
        getRepositories: function (searchWord) {
            return getRepositories(searchWord);
        },
        isRepositoryBookmarked: function (repoId) {
            return isRepositoryBookmarked(repoId);
        },
        toggleRepositoryBookmark: function (repoId) {
            return toggleRepositoryBookmark(repoId);
        },
        getBookmarkedRepositories: getBookmarkedRepositories
    }
}

RepositoriesFactory.$inject = ['$http'];