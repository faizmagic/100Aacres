
function propertyListCtrl($scope, Property) {
//    $http.get('app/listings/listings.json').success(function (data) {
//        $scope.properties = data;
//    }).error(function (data, status) {
//        alert('error ' + status);
    //    });
    Property.newListings().then(function (response) {
        $scope.allListings = response;
        //$scope.properties = response;
        $scope.bigTotalItems = response.length;
        loadDataForCurrentPage(0);
    });
    //$scope.allListings = Property.newListings();
    //$scope.properties = Property.newListings();

    //Pagination settings
    //$scope.bigTotalItems = $scope.properties.length;
    $scope.currentPage = 4;
    $scope.maxSize = 5;
    $scope.bigCurrentPage = 1;
    $scope.itemsPerPage = 10;
    $scope.setPage = function (pageNo) {
        $scope.bigCurrentPage = pageNo;
        loadDataForCurrentPage(pageNo-1);
    };

    var loadDataForCurrentPage = function (currentPageNo) {
        var itemsPerPage = $scope.itemsPerPage;
        var totalItems = $scope.totalItems;
        var startIndex = (itemsPerPage * currentPageNo);
        var endIndex = startIndex + itemsPerPage;

        if (startIndex > 0) {
            startIndex = startIndex + 1;
        }

        $scope.properties = $scope.allListings.slice(startIndex, endIndex);
    }

    //$scope.$watch('bigCurrentPage', loadDataForCurrentPage(bigCurrentPage), false);

}

//function loadDataForCurrentPage($scope, currentPageNo) {
//    var itemsPerPage = $sccope.itemsPerPage;
//    var totalItems = $scope.totalItems;
//    var startIndex = (itemsPerPage * currentPageNo);
//    var endIndex = startIndex + itemsPerPage;

//    if (startIndex > 0) {
//        startIndex = startIndex + 1;
//    }

//    $scope.properties = $scope.allListings.slice(startIndex, endIndex);
//}