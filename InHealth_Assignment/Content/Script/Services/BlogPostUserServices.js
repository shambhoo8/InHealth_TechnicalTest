inHealthAssignmentApp.factory('BlogPostUserServices', function ($resource) {
    return $resource("/Api/BlogPostUser/GetPostByUserService",
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