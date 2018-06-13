var SingleRepositoryDirective = function (RepositoriesFactory) {
    return {
        restrict: 'E',
        scope: {
            repository: '='
        },
        link: function ($scope, element, attrs) {

            $scope.toggleBookmark = function (repo) {
                RepositoriesFactory.toggleRepositoryBookmark(repo);
            }

            $scope.isRepoBookmarked = function (repo) {
                return RepositoriesFactory.isRepositoryBookmarked(repo.id);
            }
        },
        templateUrl: '/repositories/Repository'
    }
};

SingleRepositoryDirective.$inject = ['RepositoriesFactory'];