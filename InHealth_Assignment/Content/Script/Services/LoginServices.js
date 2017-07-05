inHealthAssignmentApp.factory('LoginServices', function ($resource) {
    return $resource("/Api/Login/ValidateUserService",
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