inHealthAssignmentApp.factory('PostDetailServices', function ($resource) {
    return $resource("/Api/PostDetail/GetPostDetailService",
        {},
        {
            post: {
                method: 'POST', isArray: false,
                headers: { 'Content-Type': 'application/json' }
            },
            put: {
                method: 'PUT'
            },
            get: {
                method: 'GET'
            }
        });
});

inHealthAssignmentApp.factory('PostCommentServices', function ($resource) {
    return $resource("/Api/PostComments/SaveCommentService",
        {},
        {
            post: {
                method: 'POST', isArray: false,
                headers: { 'Content-Type': 'application/json' }
            },
            put: {
                method: 'PUT'
            },
            get: {
                method: 'GET'
            }
        });
});