inHealthAssignmentApp.controller('LoginController', ['$http', '$scope', '$routeParams', '$location', 'LoginServices',
    function ($http, $scope, $routeParams, $location, LoginServices) {

        $scope.dataLoading = false;

        $scope.submit = function () {
            $scope.dataLoading = true;
            LoginServices.put($scope.user, function (response) {
                if (response.Success == true) {
                    toastr.success(response.Message);
                    $scope.dataLoading = false;
                    sessionStorage.UserId = response.UserId;
                   // $location.path('/BlogPostUser');
                    $location.path(response.RedirectURL);
                }
                else {
                    toastr.warning(response.Message);
                    $scope.dataLoading = false;
                }
            });
        }
    }]);