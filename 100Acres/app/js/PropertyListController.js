
function propertyListCtrl($scope, Property, Page) {
    Property.newListings().then(function (response) {
        $scope.allListings = response;
        $scope.PageSettings = Page.PageSettings;
        $scope.PageSettings.bigTotalItems = response.length;
        $scope.properties = Page.loadDataForCurrentPage($scope.allListings, 1);
    });
    
    $scope.PageSettings = Page.PageSettings;
    $scope.PageSettings.setPage = function (pageNo) {
        $scope.bigCurrentPage = pageNo;
        $scope.properties = Page.loadDataForCurrentPage($scope.allListings, pageNo);
    };
    //$scope.$watch('bigCurrentPage', loadDataForCurrentPage(bigCurrentPage), false);
}