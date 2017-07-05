
inHealthAssignmentApp.controller('UserRegistrationController', ['$http', '$scope', '$routeParams', '$location', 'UserRegistrationServices', 
    function ($http, $scope, $routeParams, $location, UserRegistrationServices) {

        $scope.dataLoading = false;
        $scope.Register = function () {
            $scope.dataLoading = true;
            UserRegistrationServices.post($scope.user, function (data) {
                if (data.Success == true) {
                    toastr.success(data.Message);
                    $location.path('/login');
                }
                else {
                    toastr.warning(data.Message);
                    $scope.dataLoading = false;
                }
            });
        }


    }]);