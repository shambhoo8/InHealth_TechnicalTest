inHealthAssignmentApp.factory('UserRegistrationServices', function ($resource) {
    return $resource("/Api/UserRegistration/RegisterNewUserService",
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
