
var pCurrentPage = 0; //PageIndex
var pPageItems = 10;   //PageSize
var pOrderBy = "";    //SortBy
var pOrderByReverse = true;  //SortDirection = 0
var pSearchText = "";


inHealthAssignmentApp.controller('BlogPostListController', ['$http', '$scope', '$routeParams', '$location', 'BlogPostListServices',
    function ($http, $scope, $routeParams, $location, BlogPostListServices) {

        if (sessionStorage.length == 0) {
            $location.path('/Login');
            return;
        }

        $scope.setCurrentPage_BlogPost = 0;
        $scope.GlobalFilter_BlogPost = '';
        $scope.OrderBy_BlogPost = '';
        $scope.OrderByReversed_BlogPost = false;
        $scope.PageItemsCount_BlogPost = 10;
        $scope.HiddenSearch = new Object();
        
        BlogPostDetailsSearch = function () {
            $('.tr-ng-grid tbody tr.blank_row').remove();
            var htmlToAppend = '<tbody><tr class=blank_row><td colspan=13>No Data found, please apply filters and try again.</td></tr></tbody>';

            BlogPostListServices.get(function (response) {
                $scope.BlogPostTotalCount = response.TotalCount;
                $scope.BlogPostList = response.BlogPostList;

                if (response.TotalCount == 0) {
                    $('.tr-ng-grid ').append(htmlToAppend);
                }
            });
        }

        $scope.onServerSideItemsRequested = function (currentPage, pageItems, filterBy, filterByFields, orderBy, orderByReverse) {
            //alert("calling");
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
           
            BlogPostDetailsSearch();
        }

        $scope.DeletePost = function (postId) {
            if (confirm("Are you sure? you want to delete this post?")){
                var searchCriteria = new Object();
                searchCriteria.blogPostId = postId;

                BlogPostListServices.post(searchCriteria, function (data) {
                    if (data.Success == true) {
                        toastr.success(data.Message);
                        BlogPostDetailsSearch();
                    }
                    else {
                        toastr.warning(data.Message);

                    }
                });
            }
        }

    }]);