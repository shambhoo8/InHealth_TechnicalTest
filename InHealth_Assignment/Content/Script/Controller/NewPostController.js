
inHealthAssignmentApp.controller('NewPostController', ['$http', '$scope', '$routeParams', '$location', 'NewPostServices',
    function ($http, $scope, $routeParams, $location, NewPostServices) {

        if (sessionStorage.length == 0) {
            $location.path('/Login');
            return;
        }

        $scope.dataLoading = false;

        $scope.Submit = function () {
            $scope.dataLoading = true;
            //$scope.post.CreatedBy = sessionStorage.UserId;
            
            NewPostServices.post($scope.post, function (response) {
                if (response.Success == true) {
                    toastr.success(response.Message);
                    $location.path(response.RedirectURL);
                }
                else {
                    toastr.warning(response.Message);
                    $scope.dataLoading = false;
                }
            });
        }

    }]);