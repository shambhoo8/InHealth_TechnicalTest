
var pCurrentPage = 0; //PageIndex
var pPageItems = 10;   //PageSize
var pOrderBy = "";    //SortBy
var pOrderByReverse = true;  //SortDirection = 0
var pSearchText = "";

inHealthAssignmentApp.controller('UserListController', ['$http', '$scope', '$routeParams', '$location', 'UserListServices',
    function ($http, $scope, $routeParams, $location, UserListServices) {

        $scope.setCurrentPage_UserList = 0;
        $scope.GlobalFilter_UserList = '';
        $scope.OrderBy_UserList = '';
        $scope.OrderByReversed_UserList = false;
        $scope.PageItemsCount_UserList = 10;
        $scope.HiddenSearch = new Object();

        if (sessionStorage.length == 0) {
            $location.path('/Login');
            return;
        }

        UserListDetailsSearch = function () {
            $('.tr-ng-grid tbody tr.blank_row').remove();
            var htmlToAppend = '<tbody><tr class=blank_row><td colspan=13>No Data found, please apply filters and try again.</td></tr></tbody>';

            UserListServices.get(function (response) {
                $scope.UserListTotalCount = response.TotalCount;
                $scope.UsersList = response.userRegistrationList;

                if (response.TotalCount == 0) {
                    $('.tr-ng-grid ').append(htmlToAppend);
                }
            });
        }

        $scope.onServerSideItemsRequested = function (currentPage, pageItems, filterBy, filterByFields, orderBy, orderByReverse) {
            pCurrentPage = currentPage;
            pPageItems = pageItems;

            if (orderBy == null)
                orderBy = "";

            pOrderBy = orderBy.split('.').pop();;
            pOrderByReverse = orderByReverse;

            if (filterBy == undefined)
                pSearchText = '';
            pSearchText = filterBy;

            var searchCriteria = new Object();

            // general parameters of grid
            searchCriteria.PaginationRequest = new Object();
            searchCriteria.PaginationRequest.SearchText = pSearchText;
            searchCriteria.PaginationRequest.PageIndex = pCurrentPage;
            searchCriteria.PaginationRequest.PageSize = pPageItems;

            // w.r.t sort
            searchCriteria.PaginationRequest.Sort = new Object();
            searchCriteria.PaginationRequest.Sort.SortBy = pOrderBy;
            searchCriteria.PaginationRequest.Sort.SortDirection = (pOrderByReverse ? 1 : 0);

            UserListDetailsSearch();
        }

        $scope.UpdateRole = function (userId, role) {
            
            if (role == "Admin") {
                toastr.warning("Admin role cann't be updated!!!");
                return;
            }
            if (confirm("Are you sure? you want to update user role?")) {
                var searchCriteria = new Object();
                searchCriteria.UserId = userId;

                UserListServices.post(searchCriteria, function (data) {
                    if (data.Success == true) {
                        toastr.success(data.Message);
                        UserListDetailsSearch();
                    }
                    else {
                        toastr.warning(data.Message);
                    }
                });
            }
        }

        $scope.DeleteUser = function (userId, role) {

            if (role == "Admin") {
                toastr.warning("Admin role cann't be deleted!!!");
                return;
            }
            if (confirm("Are you sure? you want to delete this user?")) {
                var searchCriteria = new Object();
                searchCriteria.UserId = userId;

                UserListServices.put(searchCriteria, function (data) {
                    if (data.Success == true) {
                        toastr.success(data.Message);
                        UserListDetailsSearch();
                    }
                    else {
                        toastr.warning(data.Message);
                    }
                });
            }
        }
        

    }]);