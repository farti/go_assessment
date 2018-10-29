var AssetControllers = angular.module("AssetControllers", []);

// this controller call the api method and display the list of asset
// in list.html
AssetControllers.controller("ListController", ['$scope', '$http',
    function ($scope, $http) {
        $http.get('/api/asset').success(function (data) {
            $scope.asset = data;
        });
    }]
);

// this controller call the api method and display the record of selected assets
// in delete.html and provide an option for delete
AssetControllers.controller("DeleteController", ['$scope', '$http', '$routeParams', '$location',
    function ($scope, $http, $routeParams, $location) {

        $scope.id = $routeParams.id;
        $http.get('/api/asset/' + $routeParams.id).success(function (data) {
            $scope.assetname = data.AssetName;
            $scope.country = data.Country;
            $scope.mimetype = data.MimeType;
        });

        $scope.delete = function () {

            $http.delete('/api/asset/' + $scope.id).success(function (data) {
                $location.path('/list');
            }).error(function (data) {
                $scope.error = "An error has occured while deleting asset! " + data;
            });
        };
    }
]);

// this controller call the api method and display the record of selected asset
// in edit.html and provide an option for create and modify the asset and save the asset record
AssetControllers.controller("EditController", ['$scope', '$filter', '$http', '$routeParams', '$location',
    function ($scope, $filter, $http, $routeParams, $location) {

        $scope.id = 0;
        $scope.save = function () {

            var obj = {
                Id: $scope.id,
                AssetName: $scope.assetname,
                Country: $scope.country,
                MimeType: $scope.mimetype,
            };

            if ($scope.id == 0) {

                $http.post('/api/asset/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    $scope.error = "An error has occured while adding asset! " + data.ExceptionMessage;
                });
            }
            else {

                $http.put('/api/asset/', obj).success(function (data) {
                    $location.path('/list');
                }).error(function (data) {
                    console.log(data);
                    $scope.error = "An Error has occured while Saving customer! " + data.ExceptionMessage;
                });
            }
        }

        if ($routeParams.id) {

            $scope.id = $routeParams.id;
            $scope.title = "Edit Asset";

            $http.get('/api/asset/' + $routeParams.id).success(function (data) {
                $scope.assetname = data.AssetName;
                $scope.country = data.Country;
                $scope.mimetype = data.MimeType;

                $scope.getStates();
            });
        }
        else {
            $scope.title = "Create New Asset";
        }
    }
]);