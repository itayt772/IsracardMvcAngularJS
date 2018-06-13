var AngularApp = angular.module('AngularApp', ['ui.router', 'ui.bootstrap']);

//controllers
AngularApp.controller('LayoutController', LayoutController);
AngularApp.controller('RepoSearchController', RepoSearchController);
AngularApp.controller('BookmarkedReposController', BookmarkedReposController);

// directives
AngularApp.directive('singleRepository', SingleRepositoryDirective);
AngularApp.directive('onEnter', OnEnterDirective);

// services
AngularApp.factory('RepositoriesFactory', RepositoriesFactory);

var configFunction = function ($stateProvider, $urlRouterProvider, $locationProvider) {

    $locationProvider.hashPrefix('');

    $stateProvider
            .state('reposearch', {
                url: '/reposearch',
                views: {
                    "mainContainer": {
                        templateUrl: '/repositories/search',
                        controller: 'RepoSearchController'
                    }
                }
            })
            .state('bookmakredrepos', {
                url: '/bookmakredrepos',
                views: {
                    "mainContainer": {
                        templateUrl: '/repositories/BookmarkedRepos',
                        controller: 'BookmarkedReposController'
                    }
                }
            });

    // default page
    $urlRouterProvider.otherwise('/reposearch');
}
configFunction.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

AngularApp.config(configFunction);