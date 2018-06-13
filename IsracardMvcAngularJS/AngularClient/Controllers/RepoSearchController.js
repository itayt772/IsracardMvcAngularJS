var RepoSearchController = function ($scope, RepositoriesFactory) {

    $scope.models = {
        title: 'Repositories Search',
        repositorySearchVal: '',
        repositoriesResults: [],
        isLoadingRepos: false
    };

    var currentSearchVal = '';

    $scope.searchRepositories = function () {
        // check if the same word already sent so we dont need to get again
        if (currentSearchVal === $scope.models.repositorySearchVal) return;

        currentSearchVal = $scope.models.repositorySearchVal;

        if (currentSearchVal === '') {
            $scope.models.repositoriesResults = [];
            return;
        }

        $scope.models.isLoadingRepos = true;
        $scope.models.repositoriesResults = [];

        RepositoriesFactory.getRepositories(currentSearchVal)
            .then(function (data) {
                $scope.models.repositoriesResults = data.data.items;
            })
            .finally(function () {
                $scope.models.isLoadingRepos = false;
            });
    }

    $scope.shouldDisplayLoadingResults = function () {
        debugger;
        return $scope.models.isLoadingRepos;
    }

    $scope.shouldDisplayNoResults = function () {
        return (!$scope.models.isLoadingRepos && $scope.models.repositoriesResults.length === 0);
    }
}

RepoSearchController.$inject = ['$scope', 'RepositoriesFactory'];