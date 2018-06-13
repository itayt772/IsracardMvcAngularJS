var BookmarkedReposController = function ($scope, RepositoriesFactory) {
    $scope.models = {
        title: 'Bookmarked repositories',
        repositories: RepositoriesFactory.getBookmarkedRepositories()
    };
}

BookmarkedReposController.$inject = ['$scope', 'RepositoriesFactory'];