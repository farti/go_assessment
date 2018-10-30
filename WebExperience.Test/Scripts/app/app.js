var myApp = angular.module('myApp', [
    'ngRoute',
    'AssetControllers',
    'smart-table',
    'ui.bootstrap'
]);

myApp.config(['$routeProvider', function ($routeProvider) {

    $routeProvider
        .when('/list', {
            templateUrl: 'asset/list.html',
            controller: 'ListController'
        }).
        when('/create', {
            templateUrl: 'asset/edit.html',
            controller: 'EditController'
        }).
        when('/edit/:id', {
            templateUrl: 'asset/edit.html',
            controller: 'EditController'
        }).
        when('/delete/:id', {
            templateUrl: 'asset/delete.html',
            controller: 'DeleteController'
        }).
        otherwise({
            redirectTo: '/list'

        });

}]);