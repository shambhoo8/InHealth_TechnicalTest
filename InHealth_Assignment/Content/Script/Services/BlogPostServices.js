inHealthAssignmentApp.factory('BlogPostServices', function ($resource) {
    return $resource("/Api/BlogPost/GetBlogPostService",
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