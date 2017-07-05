inHealthAssignmentApp.controller('BlogPostController', ['$http', '$scope', '$routeParams', '$location', 'BlogPostServices',
    function ($http, $scope, $routeParams, $location, BlogPostServices) {

        delete sessionStorage.UserId;

        var blogPostPublicUser = function () {
           
            BlogPostServices.get(function (response) {
                $scope.BlogPostList = response.BlogPostList;
               
                if (response.TotalCount == 0) {
                    $scope.message = 'No post found !!!';
                }
                else {
                    $scope.message = '';
                }
            });
        }

        blogPostPublicUser();

        $scope.RedirectToPostDetail = function (blogPostId) {
            sessionStorage.blogPostId = blogPostId;
            $location.path('/PostDetail');
        }

    }]);