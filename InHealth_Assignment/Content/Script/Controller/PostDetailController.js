
inHealthAssignmentApp.controller('PostDetailController', ['$http', '$scope', '$routeParams', '$location', 'PostDetailServices','PostCommentServices',
    function ($http, $scope, $routeParams, $location, PostDetailServices, PostCommentServices) {

        var _BlogPostId = 0;

        if (sessionStorage.blogPostId == null) {
            $location.path('/BlogPost');
        }
        var filtercriteria = new Object();
        filtercriteria.blogPostId = sessionStorage.blogPostId;
        _BlogPostId = sessionStorage.blogPostId;
        delete sessionStorage.blogPostId;

        Fn_PostDetails = function () {
            PostDetailServices.post(filtercriteria, function (response) {
                $scope.PostContent = response.PostContent;
                $scope.Title = response.Title;
                $scope.Author = response.Author;
                $scope.CreatedDate = response.CreatedDate;

                fn_GetCommentsData();
            });
        }

        $scope.SaveComment = function () {

            if ($scope.Comment == "" || $scope.Comment == null)
            {
                toastr.error("Comment is required!!!");
                return;
            }
            var saveData = new Object();
            saveData.blogPostId = _BlogPostId;
            saveData.commentContent = $scope.Comment;

            PostCommentServices.post(saveData, function (response) {
                if (response.Success == true) {
                    toastr.success(response.Message);
                    $scope.Comment = "";
                    fn_GetCommentsData();
                }
                else {
                    toastr.warning(response.Message);
                }
            });
        }

     var  fn_GetCommentsData = function () {
           
            var filtercriteria = new Object();
            filtercriteria.blogPostId = _BlogPostId;

            PostCommentServices.put(filtercriteria, function (response) {
                $scope.CommentList = response.CommentList;
            });
        }

        Fn_PostDetails();
    }]);